using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUserRepository
    {
        Task SaveAsync(User post);
        Task<User> FindByEmailAndPassword(string email, string v);
    }
}
