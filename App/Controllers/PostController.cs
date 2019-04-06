using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using Domain;
using Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Services;
using Microsoft.Extensions.Options;
using App.Helpers;

namespace App.Controllers
{
    [Route("/api/[controller]")]
    public class PostController : Controller
    {
        private PostService postService;

        public PostController(IOptions<AzureStorageConfig> config)
        {
            postService = new PostService(config.Value);
        }

        [HttpGet]
        public ObjectResult GetAll()
        {
            try
            {
                var posts = postService.GetAll();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ObjectResult> Save(NewPostData newPost)
        {
            try
            {
                await postService.Save(newPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok("OK");
        }
    }
}
