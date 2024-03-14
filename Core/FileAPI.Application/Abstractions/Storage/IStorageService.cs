using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Abstractions.Storage
{
    public interface IStorageService
    {
        Task<(string fileName, string path)> UploadSingleAsync(string path, IFormFile file);
        void Delete(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
        bool FileExist(string path, string fileName);
    }
}
