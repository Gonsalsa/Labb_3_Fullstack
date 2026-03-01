using System.ComponentModel.DataAnnotations;

namespace Labb_3_Fullstack.Data.Enteties
{
    public class Bid
    {

        [Key]
        public int BidId { get; set; }
        
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        //Främmande nycklar
        public int AuctionId { get; set; }
        public int BidPlacerId { get; set; }
    }
}
