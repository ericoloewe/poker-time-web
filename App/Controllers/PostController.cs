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
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    [Route("/api/[controller]")]
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult GetAll()
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

        [Authorize]
        [HttpPost("{postId}/like")]
        public async Task<ActionResult> Like(string postId)
        {
            try
            {
                await postService.Like(postId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok("OK");
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Save(NewPostData newPost)
        {
            try
            {
                await postService.Save(newPost);
            }
            catch (Exception ex)
            {
                return BadRequest(Json(ex));
            }

            return Ok(Json("OK"));
        }
    }
}
