using Labb_3_Fullstack.Data.Enteties;
using Labb_3_Fullstack.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_Fullstack.Data.Repos
{
    public class BidRepo : IBidRepo
    {
        private readonly AppDbContext _context;
        public BidRepo (AppDbContext context) => _context = context;

        public async Task AddBidAsync(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bid>> GetBidsForAuctionAsync(int auctionId)
        {
            return await _context.Bids.Where(b => b.AuctionId == auctionId)
                                        .OrderByDescending(b => b.Amount)
                                        .ToListAsync();
        }

        public async Task<Bid?> GetHighestBidAsync(int auctionId)
        {
            return await _context.Bids.Where(b => b.AuctionId == auctionId)
                                        .OrderByDescending(b =>b.Amount)
                                        .FirstOrDefaultAsync();
        }
    }
}
