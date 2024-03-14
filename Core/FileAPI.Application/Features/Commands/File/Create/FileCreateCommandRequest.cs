using FileAPI.Application.Features.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Features.Commands.File.Create
{
    public class FileCreateCommandRequest:UserInformation,IRequest<FileCreateCommandResponse>
    {
        public IFormFile? File { get; set; }
        public string Folder { get; set; }
    }
}
