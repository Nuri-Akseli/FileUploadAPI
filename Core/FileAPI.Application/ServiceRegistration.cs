using FileAPI.Application.Beheviors;
using FileAPI.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<ExceptionMiddleware>();
            service.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            

            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            ValidatorOptions.Global.LanguageManager.Culture=new System.Globalization.CultureInfo("tr");
            service.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
