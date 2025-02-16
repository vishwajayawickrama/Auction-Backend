using BettingSite.Models;
using BettingSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace BettingSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaceBidController : ControllerBase
{
    private readonly ILogger<PlaceBidController> _logger;
    private readonly IPlaceBidService _placeBidService;

    public PlaceBidController(ILogger<PlaceBidController> logger, IPlaceBidService placeBidService)
    {
        _logger = logger;
        _placeBidService = placeBidService;
    }
    [HttpPost]
    public async Task<ActionResult<BidDTO>> PlaceBid(BidPostDTO bidPostDTO)
    {
        _logger.LogInformation("Placing Bid");
        return await _placeBidService.PlaceBid(bidPostDTO);
    }
}