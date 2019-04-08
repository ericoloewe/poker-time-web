

using System;
using System.Threading.Tasks;
using App.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace App.Services
{
    public interface ICloudStorageService
    {
        Task<string> SaveFile(IFormFile file, string containerName);
    }

    public class CloudStorageService : ICloudStorageService
    {
        private AzureStorageConfig azureStorageConfigs;

        public CloudStorageService(IOptions<AzureStorageConfig> config)
        {
            this.azureStorageConfigs = config.Value;
        }

        public async Task<string> SaveFile(IFormFile file, string containerName)
        {
            string fileUrl = null;

            if (StorageHelper.IsImage(file))
            {
                using (var stream = file.OpenReadStream())
                {
                    var fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssfffffff")}_{file.FileName}";

                    fileUrl = await StorageHelper.UploadFileToStorage(stream, fileName, containerName, azureStorageConfigs);
                }
            }
            else
            {
                throw new ArgumentException("Unsuported file");
            }

            return fileUrl;
        }
    }
}
