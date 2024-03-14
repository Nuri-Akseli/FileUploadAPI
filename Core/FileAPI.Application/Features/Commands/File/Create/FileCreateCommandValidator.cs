using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Features.Commands.File.Create
{
    public class FileCreateCommandValidator:AbstractValidator<FileCreateCommandRequest>
    {
        public FileCreateCommandValidator()
        {
            RuleFor(file => file.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .WithName("Kullanıcı Adı");

            RuleFor(file => file.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .WithName("Şifre");

            RuleFor(file => file.Folder)
               .NotEmpty()
               .NotNull()
               .WithName("Dosya İsmi");
        }
    }
}
