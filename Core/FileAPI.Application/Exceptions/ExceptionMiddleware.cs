using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }catch (Exception exception)
            {
                await HandleExceptionAsync(context,exception);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
                return context.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(messages => messages.ErrorMessage),
                    StatusCode = statusCode

                }.ToString());

            List<string> errors = new()
            {
                exception.Message
            };

            return context.Response.WriteAsync(new ExceptionModel()
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());
        }
        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                ForbiddenException => StatusCodes.Status403Forbidden,
                NullReferenceException => StatusCodes.Status400BadRequest,
                AuthenticationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
