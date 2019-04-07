using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> FindByEmailAndPassword(string email, string password)
        {
            using (var db = new PokerTimeContext())
            {
                return db.Users
                    .Where(u => u.Email.Equals(email) && u.Password.Equals(password))
                    .Include(u => u.Image)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task SaveAsync(User User)
        {
            using (var db = new PokerTimeContext())
            {
                await db.Users.AddAsync(User);
                await db.SaveChangesAsync();
            }
        }
    }
}
