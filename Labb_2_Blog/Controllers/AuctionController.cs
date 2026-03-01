using Labb_3_Fullstack.Core.Interface;
using Labb_3_Fullstack.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3_Fullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        //Söka på auktioner

        [HttpGet]
        public async Task<IActionResult> GetActive()
        {
            var activeAuctions = await _auctionService.GetActiveAuctionsAsync();
            return Ok(activeAuctions);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchActiveByTitle([FromQuery] string title)
        {
            var ActiveAuction = await _auctionService.SearchActiveAuctionsAsync(title);
            if (ActiveAuction == null)
            {
                return NotFound();
            }

            return Ok(ActiveAuction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActiveAuctionInformation(int id)
        {
            var ActiveAuction = await _auctionService.GetAuctionDetailsAsync(id);
            if (ActiveAuction == null)
            {
                return NotFound();
            }
            return Ok(ActiveAuction);
        }


        //Skapa auktion
        [HttpPost]
        public async Task<IActionResult> CreateAuction(CreateAuctionDTO dto)
        {
            var ok = await _auctionService.CreateAuctionAsync(dto);
            if (!ok)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
