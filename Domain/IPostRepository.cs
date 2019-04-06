using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllWithImages();
        Task SaveAsync(Post post);
    }
}
