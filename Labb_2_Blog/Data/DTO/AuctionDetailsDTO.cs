namespace Labb_3_Fullstack.Data.DTO
{
    public class AuctionDetailsDTO
    {
        public int AuctionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public decimal HighestBid { get; set; }
        public int OwnerId { get; set; }

        public List<BidDTO> Bids { get; set; } = new();
    }
}
