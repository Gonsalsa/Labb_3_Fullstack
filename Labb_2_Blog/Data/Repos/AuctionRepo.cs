using Labb_3_Fullstack.Data.DTO;
using Labb_3_Fullstack.Data.Enteties;
using Labb_3_Fullstack.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_Fullstack.Data.Repos
{
    public class AuctionRepo : IAuctionRepo
    {
        private readonly AppDbContext _context;
        public AuctionRepo(AppDbContext context) => _context = context;

        public async Task AddAuctionAsync(Auction auction)
        {
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Auction>> GetActiveAuctionsAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.Auctions.Where(a => a.EndDate > now).ToListAsync();
        }

        public async Task<Auction?> GetAuctionByIdAsync(int id)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == id);
        }

        public async Task<List<Auction>> SearchActiveByTitleAsync(string title)
        {
            var now = DateTime.UtcNow;
            return await _context.Auctions
                    .Where(a => a.EndDate > now && a.AuctionTitle.Contains(title))
                    .ToListAsync();
        }
    }
}
