using Microsoft.AspNetCore.Http;
using PersonelBlogBackend.Application.Abstractions.Storage;
using PersonelBlogBackend.Infrastructure.Operations;

namespace PersonelBlogBackend.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
            => await _storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName)
            => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
            => _storage.HasFile(pathOrContainerName, fileName);

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
            => await _storage.UploadAsync(pathOrContainerName, files);

        public string FileRenameAsync(string path, string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string regulatedFileName = NameOperation.CharacterRegulatory(oldName);

            var files = Directory.GetFiles(path, regulatedFileName + "*");

            if (files.Length == 0)
                return $"{regulatedFileName}-1{extension}";

            List<int> fileNumbers = new List<int>();
            foreach (var file in files)
            {
                string fileWithoutPath = Path.GetFileNameWithoutExtension(file);
                int lastHyphenIndex = fileWithoutPath.LastIndexOf("-");

                if (lastHyphenIndex != -1 && int.TryParse(fileWithoutPath.Substring(lastHyphenIndex + 1), out int fileNumber))
                {
                    fileNumbers.Add(fileNumber);
                }
            }

            int nextNumber = (fileNumbers.Count > 0) ? fileNumbers.Max() + 1 : 1;

            return $"{regulatedFileName}-{nextNumber}{extension}";
        }
    }
}
