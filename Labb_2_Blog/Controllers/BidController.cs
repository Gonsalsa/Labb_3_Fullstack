using Labb_3_Fullstack.Core.Interface;
using Labb_3_Fullstack.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3_Fullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {

        private readonly IBidService _BidService;

        public BidController(IBidService bidService)
        {
            _BidService = bidService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBid(int auctionId, PlaceBidDTO dto)
        {
            var (ok, error) = await _BidService.PlaceBidAsync(auctionId, dto);

            if (!ok)
            {
                return BadRequest("Auktionen kunde inte laddas in");
            }

            return Ok();
        }

    }
}
