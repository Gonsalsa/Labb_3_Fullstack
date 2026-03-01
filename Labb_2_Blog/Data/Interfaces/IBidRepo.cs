using Labb_3_Fullstack.Data.Enteties;

namespace Labb_3_Fullstack.Data.Interfaces
{
    public interface IBidRepo
    {
        Task<List<Bid>> GetBidsForAuctionAsync(int auctionId);
        Task<Bid?> GetHighestBidAsync(int auctionId);
        Task AddBidAsync(Bid bid);
    }
}
