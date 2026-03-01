namespace Labb_3_Fullstack.Data.DTO
{
    public class CreateAuctionDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int OwnerId { get; set; }

    }
}
