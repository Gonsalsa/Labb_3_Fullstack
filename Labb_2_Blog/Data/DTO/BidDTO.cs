namespace Labb_3_Fullstack.Data.DTO
{
    public class BidDTO
    {
        public int BidId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
