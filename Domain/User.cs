using System.Collections.Generic;

namespace Domain
{
    public class User : AuditableEntity
    {
        public string Id { get; set; }
        public IList<Post> Posts { get; set; }
        public Image Image { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}