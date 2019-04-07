namespace Domain
{
    public class Image : AuditableEntity
    {
        public string Id { get; set; }
        public string Url { get; set; }

        public Image(string url)
        {
            this.Url = url;
        }
    }
}