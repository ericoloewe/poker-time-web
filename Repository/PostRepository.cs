using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Domain;

namespace Repository
{
    public class PostRepository : IPostRepository
    {
        private static IList<Post> Posts = new List<Post>()
        {
            new Post() {
                Id = "1",
                Image = new Image("https://assets.entrepreneur.com/content/3x2/2000/20151023204134-poker-game-gambling-gamble-cards-money-chips-game.jpeg?width=700&crop=2:1"),
                Message= "Some quick example text to build on the card title and make up the bulk of the card's content."
            },
            new Post() {
                Id = "2",
                Image = new Image("https://3c1703fe8d.site.internapcdn.net/newman/gfx/news/hires/2018/aguidetopoke.jpg"),
                Message= "Lorem ipsum dolor sit amet consectetur adipisicing elit. Facilis, esse voluptatem ex iure aliquam quas sed aperiam ut molestias! Aperiam, voluptates ex eaque ullam facere blanditiis doloribus quis reiciendis provident."
            },
            new Post() {
                Id = "3",
                Image = new Image("http://www.clearwatercasino.com/wp-content/uploads/2014/03/Web-Landing-700x386.png"),
                Message= "Sit amet consectetur adipisicing elit. Facilis, esse voluptatem ex iure aliquam quas sed aperiam ut molestias! Aperiam, voluptates ex eaque ullam facere blanditiis doloribus quis reiciendis provident."
            }
        };

        public IList<Post> GetAll()
        {
            using (var db = new PokerTimeContext())
            {
                return db.Posts.ToList();
            }
        }

        public void Save(Post post)
        {
            using (var db = new PokerTimeContext())
            {
                db.Posts.Add(post);
            }
        }
    }
}
