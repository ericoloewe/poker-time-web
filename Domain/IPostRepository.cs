using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IPostRepository
    {
        IList<Post> GetAll();
        void Save(Post post);
    }
}
