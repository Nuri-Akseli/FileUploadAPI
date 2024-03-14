using FileAPI.Application.Abstractions.Storage;
using FileAPI.Application.Repositories.UserRepositories;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Features.Commands.File.Create
{
    public class FileCreateCommandHandler : IRequestHandler<FileCreateCommandRequest, FileCreateCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IStorageService _storageService;
        public FileCreateCommandHandler(IUserReadRepository userReadRepository, IStorageService storageService)
        {
            _userReadRepository= userReadRepository;
            _storageService= storageService;
        }
        public async Task<FileCreateCommandResponse> Handle(FileCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.User user =await _userReadRepository.GetSingleAsync(user=>user.Username== request.Username && user.Password==request.Password && user.IsActive==true);

            if (user==null)
                throw new BadRequestException("Kullanıcı Adı veya Şifre Yanlış");

            (string fileName, string path) uploadedFile = new();

            if (request.File == null)
                throw new BadRequestException("Dosya Bulunamadı");

            uploadedFile = await _storageService.UploadSingleAsync($"{user.ContainerName}\\{request.Folder}", request.File);
            return new()
            {
                Path = uploadedFile.path,
                Name = uploadedFile.fileName
            };
        }
    }
}
