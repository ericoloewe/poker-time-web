namespace Domain
{
    public class Like : AuditableEntity
    {
        public string Id { get; set; }
        public User Author { get; set; }
        public Post Post { get; set; }
    }
}