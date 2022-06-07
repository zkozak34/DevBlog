using DevBlog.Service.Utilities.Storage.Abstraction;
using Microsoft.AspNetCore.Http;

namespace DevBlog.Service.Utilities.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<string> UploadAsync(string pathOrContainerName, IFormFile file, string? oldFileName)
            => await _storage.UploadAsync(pathOrContainerName, file, oldFileName);

        public void Delete(string pathOrContainerName, string fileName)
            => _storage.Delete(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName)
            => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
            => _storage.HasFile(pathOrContainerName, fileName);
    }
}
