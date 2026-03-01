using Labb_3_Fullstack.Data.DTO;

namespace Labb_3_Fullstack.Core.Interface
{
    public interface IBidService
    {
        Task<(bool ok, string? error)> PlaceBidAsync(int auctionId, PlaceBidDTO dto);
    }
}
