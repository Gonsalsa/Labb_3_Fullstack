using Labb_3_Fullstack.Data.Enteties;

namespace Labb_3_Fullstack.Data.Interfaces
{
    public interface IAuctionRepo
    {
        Task<List<Auction>> GetActiveAuctionsAsync();
        Task<List<Auction>> SearchActiveByTitleAsync(string title);
        Task<Auction?> GetAuctionByIdAsync(int id);
        Task AddAuctionAsync(Auction auction);
    }
}
