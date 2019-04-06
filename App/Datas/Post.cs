using Microsoft.AspNetCore.Http;

namespace App.Datas
{
    public class PostData
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
    }

    public class NewPostData
    {
        public IFormFile Image { get; set; }
        public string Message { get; set; }
    }
}
