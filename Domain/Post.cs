using System;
using System.Collections.Generic;

namespace Domain
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public IList<Like> Like { get; set; }
    }
}
