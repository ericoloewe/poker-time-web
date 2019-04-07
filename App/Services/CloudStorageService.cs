using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using App.Helpers;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Repository;

namespace App.Services
{
    public class CloudStorageService
    {
        private AzureStorageConfig azureStorageConfigs;

        public CloudStorageService(AzureStorageConfig azureStorageConfigs)
        {
            this.azureStorageConfigs = azureStorageConfigs;
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