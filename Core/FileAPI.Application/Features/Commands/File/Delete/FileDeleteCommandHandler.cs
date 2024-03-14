using FileAPI.Application.Abstractions.Storage;
using FileAPI.Application.Repositories.UserRepositories;
using MediatR;
using Microsoft.Extensions.Primitives;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Features.Commands.File.Delete
{
    public class FileDeleteCommandHandler : IRequestHandler<FileDeleteCommandRequest, FileDeleteCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IStorageService _storageService;
        public FileDeleteCommandHandler(IUserReadRepository userReadRepository, IStorageService storageService)
        {
            _userReadRepository=userReadRepository;
            _storageService=storageService;
        }
        public async Task<FileDeleteCommandResponse> Handle(FileDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.User user = await _userReadRepository.GetSingleAsync(user => user.Username == request.Username && user.Password == request.Password && user.IsActive == true);

            if (user == null)
                throw new BadRequestException("Kullanıcı Adı veya Şifre Yanlış");

            if (request.Path == null || request.Name == null)
                throw new BadRequestException("Dosya İsmini veya Yolunu Girmediniz");

            if (!request.Path.Contains(user.ContainerName))
                throw new BadRequestException("Dosyanız Bulunamadı");


            if (!_storageService.FileExist(request.Path,request.Name))
                throw new BadRequestException("Dosya Bulunamadı");

            _storageService.Delete(request.Path, request.Name);

            return new();
        }
    }
}
