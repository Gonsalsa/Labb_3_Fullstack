namespace Labb_3_Fullstack.Data.DTO
{
    public class AuctionListDTO
    {
        public int AuctionId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime EndDate { get; set; }
        public decimal HighestBid { get; set; }
        public bool isActive { get; set; }
        public int OwnerId { get; set; }
    }
}
