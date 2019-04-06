using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using App.Helpers;
using Domain;
using Repository;

namespace App.Services
{
    public class PostService
    {
        private IPostRepository postRepository = new PostRepository();
        private CloudStorageService cloudStorageService;
        private AzureStorageConfig azureStorageConfigs;

        public PostService(AzureStorageConfig azureStorageConfigs)
        {
            cloudStorageService = new CloudStorageService(azureStorageConfigs);
        }

        public IEnumerable<PostData> GetAll()
        {
            return postRepository.GetAll().Select(p => new PostData
            {
                Id = p.Id,
                Image = p.Image.Url,
                Message = p.Message,
            });
        }

        public async Task Save(NewPostData newPost)
        {
            var url = await cloudStorageService.SaveFile(newPost.Image);

            postRepository.Save(new Post
            {
                Id = $"{new Random().Next()}",
                Image = new Image(url),
                Message = newPost.Message,
            });
        }
    }
}
