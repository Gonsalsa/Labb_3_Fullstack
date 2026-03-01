using Labb_3_Fullstack.Core.Interface;
using Labb_3_Fullstack.Data.DTO;
using Labb_3_Fullstack.Data.Enteties;
using Labb_3_Fullstack.Data.Interfaces;

namespace Labb_3_Fullstack.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IAuctionRepo _auctionRepo;
        private readonly IBidRepo _bidRepo;

        public BidService(IAuctionRepo auctionRepo, IBidRepo bidRepo)
        {
            _auctionRepo = auctionRepo;
            _bidRepo = bidRepo;
        }

        public async Task<(bool ok, string? error)> PlaceBidAsync(int auctionId, PlaceBidDTO dto)
        {
            var auction = await _auctionRepo.GetAuctionByIdAsync(auctionId);

            if (auction == null)
            {
                return (false, "Auktionen finns inte");
            }

            //Kollar om auktionen fortfarande är aktiv
            if (auction.EndDate <= DateTime.UtcNow)
            {
                return (false, "Auktionen är avslutad");
            }

            //Kollar så att du inte lägger ett bud på din egna auktion
            if (auction.CreatedByUserId == dto.UserId)
            {
                return (false, "Du kan inte buda på din egna auktion");
            }

            //Kollar så att budet är högre än nuvarande högsta
            var highest = await _bidRepo.GetHighestBidAsync(auctionId);
            var min = highest?.Amount ?? auction.Price;

            if (dto.Amount <= min)
            {
                return (false, $"Budet måste vara högre än {min} SEK.");
            }

            var bid = new Bid
            {
                AuctionId = auctionId,
                BidPlacerId = dto.UserId,
                Amount = dto.Amount,
                CreatedAt = DateTime.UtcNow,
            };

            await _bidRepo.AddBidAsync(bid);

            return (true, null);

        }
    }
}
