using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PokerTimeContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PokerTime.db");
        }
    }
}