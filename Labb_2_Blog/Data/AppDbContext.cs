using Labb_2_Blog.Data.Enteties;
using Labb_3_Fullstack.Data.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_Fullstack.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
      
    }
}
