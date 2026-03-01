using System.ComponentModel.DataAnnotations;

namespace Labb_3_Fullstack.Data.Enteties
{
    public class Auction
    {
        [Key]
        public int AuctionId { get; set;  }
        
        [Required]
        public string AuctionTitle { get; set;  }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set;  }

        public int CreatedByUserId { get; set; }
    }
}
