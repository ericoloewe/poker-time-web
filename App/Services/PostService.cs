using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using App.Helpers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace App.Services
{
    public class PostService
    {
        private const string CONTAINER_NAME = "posts";
        private IPostRepository postRepository = new PostRepository();
        private CloudStorageService cloudStorageService;
        private AzureStorageConfig azureStorageConfigs;

        public PostService(AzureStorageConfig azureStorageConfigs)
        {
            cloudStorageService = new CloudStorageService(azureStorageConfigs);
        }

        public IEnumerable<PostData> GetAll()
        {
            return postRepository.GetAllWithImages().Select(p => new PostData
            {
                Id = p.Id,
                Image = p.Image.Url,
                Message = p.Message,
            }).ToList();
        }

        public async Task Save(NewPostData newPost)
        {
            var url = await cloudStorageService.SaveFile(newPost.Image, CONTAINER_NAME);

            await postRepository.SaveAsync(new Post
            {
                Image = new Image(url),
                Message = newPost.Message,
            });
        }

        internal Task Like(string postId)
        {
            throw new NotImplementedException();
        }
    }
}
