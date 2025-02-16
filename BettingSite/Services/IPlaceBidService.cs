using BettingSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BettingSite.Services;

public interface IPlaceBidService
{
    public Task<BidDTO> PlaceBid(BidPostDTO bidPostDTO);
}