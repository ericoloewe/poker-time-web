using System;
using System.Collections.Generic;

namespace Domain
{
    public class Post : AuditableEntity
    {
        public IList<Like> Like { get; set; }
        public Image Image { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public User Author { get; set; }
    }
}
