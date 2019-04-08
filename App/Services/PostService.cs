using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using App.Helpers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository;

namespace App.Services
{

    public interface IPostService
    {
        IEnumerable<PostData> GetAll();
        Task Save(NewPostData newPost);
        Task Like(string postId);
    }

    public class PostService : IPostService
    {
        private const string CONTAINER_NAME = "posts";
        private IPostRepository postRepository;
        private IUserService userService;
        private ICloudStorageService cloudStorageService;

        public PostService(ICloudStorageService cloudStorageService, IPostRepository postRepository, IUserService userService)
        {
            this.cloudStorageService = cloudStorageService;
            this.postRepository = postRepository;
            this.userService = userService;
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
                Author = userService.GetLoggedUser()
            });
        }

        public Task Like(string postId)
        {
            throw new NotImplementedException();
        }
    }
}
