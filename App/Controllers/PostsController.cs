using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("/api/[controller]")]
    public class PostsController : Controller
    {
        private static IList<PostData> Posts = new[]
        {
            new PostData() {
                Id = "1",
                Image = "https://assets.entrepreneur.com/content/3x2/2000/20151023204134-poker-game-gambling-gamble-cards-money-chips-game.jpeg?width=700&crop=2:1",
                Message= "Some quick example text to build on the card title and make up the bulk of the card's content."
            },
            new PostData() {
                Id = "2",
                Image = "https://3c1703fe8d.site.internapcdn.net/newman/gfx/news/hires/2018/aguidetopoke.jpg",
                Message= "Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, esse voluptatem ex iure aliquam quas sed aperiam ut molestias! Aperiam, voluptates ex eaque ullam facere blanditiis doloribus quis reiciendis provident."
            },
            new PostData() {
                Id = "3",
                Image = "http://www.clearwatercasino.com/wp-content/uploads/2014/03/Web-Landing-700x386.png",
                Message= "Sit amet consectetur adipisicing elit. Facilis, esse voluptatem ex iure aliquam quas sed aperiam ut molestias! Aperiam, voluptates ex eaque ullam facere blanditiis doloribus quis reiciendis provident."
            }
        };

        [HttpGet]
        public IEnumerable<PostData> GetAll()
        {
            return Posts;
        }

        [HttpPost]
        public void Save(PostData post)
        {
            Posts.Add(post);
        }
    }
}
