using FileAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace FileAPI.Infrastructure.Services.Storage
{
    public class StorageService :Storage, IStorageService
    {
        readonly IWebHostEnvironment _webHostEnvironment;
        public StorageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void Delete(string path, string fileName)
        {
            File.Delete($"{path}\\{fileName}");
        }

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        {
            string uploadPath = $"{_webHostEnvironment.WebRootPath}\\{path}\\{fileName}";
            return File.Exists(uploadPath);
        }
        public bool FileExist(string path, string fileName)
        {
            string filePath = $"{path}\\{fileName}";
            return File.Exists(filePath);
        }

        public async Task<(string fileName, string path)> UploadSingleAsync(string path, IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            (string fileName, string path) data = new();

            string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);
            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);

            data.fileName = fileNewName;
            data.path = $"{uploadPath}\\";


            return data;
        }
        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
