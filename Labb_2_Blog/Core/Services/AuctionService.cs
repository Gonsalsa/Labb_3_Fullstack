using Labb_3_Fullstack.Core.Interface;
using Labb_3_Fullstack.Data.DTO;
using Labb_3_Fullstack.Data.Enteties;
using Labb_3_Fullstack.Data.Interfaces;
using System.Runtime.CompilerServices;

namespace Labb_3_Fullstack.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepo _auctionRepo;
        private readonly IBidRepo _bidRepo;

        public AuctionService(IAuctionRepo auctionRepo, IBidRepo bidRepo)
        {
            _auctionRepo = auctionRepo;
            _bidRepo = bidRepo;
        }

        public async Task<bool> CreateAuctionAsync(CreateAuctionDTO dto)
        {

            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddDays(7);

            var auction = new Auction
            {
                AuctionTitle = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                StartDate = startDate,
                EndDate = endDate,
                CreatedByUserId = dto.OwnerId
            };

            await _auctionRepo.AddAuctionAsync(auction);

            return true;
        }

        public async Task<List<AuctionListDTO>> GetActiveAuctionsAsync()
        {
            var auctions = await _auctionRepo.GetActiveAuctionsAsync();

            var result = new List<AuctionListDTO>();


            foreach (var a in auctions)
            {
                var highest = await _bidRepo.GetHighestBidAsync(a.AuctionId);

                result.Add(new AuctionListDTO
                {
                    AuctionId = a.AuctionId,
                    Title = a.AuctionTitle,
                    EndDate = a.EndDate,
                    HighestBid = highest?.Amount ?? a.Price,
                    isActive = a.EndDate > DateTime.UtcNow,
                    OwnerId = a.CreatedByUserId
                });
            }

            return result;
        }

        public async Task<AuctionDetailsDTO> GetAuctionDetailsAsync(int id)
        {
            var auction = await _auctionRepo.GetAuctionByIdAsync(id);

            if (auction == null)
            {
                return null;
            }

            var bids = await _bidRepo.GetBidsForAuctionAsync(id);
            var highest = bids.Count == 0 ? auction.Price : bids.Max(b => b.Amount);

            return new AuctionDetailsDTO
            {
                AuctionId = auction.AuctionId,
                Title = auction.AuctionTitle,
                Description = auction.Description,
                Price = auction.Price,
                StartDate = auction.StartDate,
                EndDate = auction.EndDate,
                IsActive = auction.EndDate > DateTime.UtcNow,
                HighestBid = highest,
                OwnerId = auction.CreatedByUserId,
                Bids = bids.Select(b => new BidDTO
                {
                    BidId = b.BidId,
                    UserId = b.BidPlacerId,
                    Amount = b.Amount,
                    CreatedAt = b.CreatedAt
                }).ToList()
            };
        }

        public async Task<List<AuctionListDTO>> SearchActiveAuctionsAsync(string title)
        {
            var auctions = await _auctionRepo.SearchActiveByTitleAsync(title);
            var result = new List<AuctionListDTO>();

            foreach (var a in auctions)
            {
                var highest = await _bidRepo.GetHighestBidAsync(a.AuctionId);
                result.Add(new AuctionListDTO
                {
                    AuctionId = a.AuctionId,
                    Title = a.AuctionTitle,
                    Price = a.Price,
                    EndDate = a.EndDate,
                    HighestBid = highest?.Amount ?? a.Price,
                    isActive = a.EndDate > DateTime.UtcNow,
                    OwnerId = a.CreatedByUserId
                });
            }

            return result;

        }
    }
}
