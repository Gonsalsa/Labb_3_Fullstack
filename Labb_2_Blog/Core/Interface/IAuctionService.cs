using Labb_3_Fullstack.Data.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Labb_3_Fullstack.Core.Interface
{
    public interface IAuctionService
    {
        Task<List<AuctionListDTO>> GetActiveAuctionsAsync();
        Task<List<AuctionListDTO>> SearchActiveAuctionsAsync(string title);
        Task<AuctionDetailsDTO> GetAuctionDetailsAsync(int id);
        Task<bool> CreateAuctionAsync(CreateAuctionDTO dto);

    }
}
