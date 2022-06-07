using Microsoft.AspNetCore.Http;

namespace DevBlog.Service.Utilities.Storage.Abstraction
{
    public interface IStorage
    {
        Task<string> UploadAsync(string pathOrContainerName, IFormFile file, string? oldFileName);
        void Delete(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
