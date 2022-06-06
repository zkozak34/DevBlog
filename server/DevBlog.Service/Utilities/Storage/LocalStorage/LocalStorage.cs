using DevBlog.Service.Utilities.Storage.Abstraction.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DevBlog.Service.Utilities.Storage.LocalStorage
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadAsync(string path, IFormFile file, string? oldFileName)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            if (oldFileName != null && HasFile(path, oldFileName))
                await DeleteAsync(uploadPath, oldFileName);

            string fileNewName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string fullUploadPath = Path.Combine(uploadPath, fileNewName);

            await CopyFileAsync(fullUploadPath, file);

            return fileNewName;
        }

        public async Task DeleteAsync(string path, string fileName)
        {
            try
            {
                File.Delete(Path.Combine(path, fileName));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        {
            string fullUploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path, fileName);
            if (File.Exists(fullUploadPath))
                return true;
            return false;
        }

        private async Task<bool> CopyFileAsync(string fullUploadPath, IFormFile file)
        {
            try
            {
                await using (FileStream stream = new FileStream(fullUploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    await stream.FlushAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
