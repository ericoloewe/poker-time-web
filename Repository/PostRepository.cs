﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetAllWithImages()
        {
            using (var db = new PokerTimeContext())
            {
                return db.Posts
                .Include(p => p.Image)
                .OrderByDescending(p => p.CreatedDate)
                .ToList();
            }
        }

        public async Task SaveAsync(Post post)
        {
            using (var db = new PokerTimeContext())
            {
                db.Users.Attach(post.Author);
                await db.Posts.AddAsync(post);
                await db.SaveChangesAsync();
            }
        }
    }
}
