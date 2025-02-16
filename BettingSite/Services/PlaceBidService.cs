using BettingSite.Data;
using BettingSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BettingSite.Services;

public class PlaceBidService : IPlaceBidService
{
    private ApplicationDbContext _context;
    private ILogger<PlaceBidService> _logger;

    public PlaceBidService(ApplicationDbContext context, ILogger<PlaceBidService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<BidDTO> PlaceBid(BidPostDTO bidPostDTO)
    {
        if (bidPostDTO is null)
        {
            _logger.LogError("bidPostDTO is null");
            throw new ArgumentNullException(nameof(bidPostDTO));
        }

        var product = await _context.Products.FindAsync(bidPostDTO.productId);
        if (product == null)
        {
            _logger.LogError("Product not found");
            throw new ArgumentNullException(nameof(bidPostDTO));
        }

        var bid = new Bid
        {
            bidPrice = bidPostDTO.bidPrice,
            productId = bidPostDTO.productId,

        };
        await _context.Bids.AddAsync(bid);
        await _context.SaveChangesAsync();

        var bidDTO = new BidDTO
        {
            bidPrice = bidPostDTO.bidPrice,
            productId = bidPostDTO.productId,
        };
        return bidDTO;
        
    }
}
