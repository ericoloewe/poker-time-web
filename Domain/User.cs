namespace Domain
{
    public class User : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Image Image { get; set; }
    }
}