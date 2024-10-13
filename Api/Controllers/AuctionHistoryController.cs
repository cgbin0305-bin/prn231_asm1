using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository;

namespace Api.Controllers;
[ApiController]
[Route("odata/[controller]")]
public class AuctionHistoryController : ODataController
{
    private readonly AuctionHistory.IAuctionHistoryRepository _auctionHistoryRepository;

    public AuctionHistoryController(AuctionHistory.IAuctionHistoryRepository auctionHistoryRepository)
    {
        _auctionHistoryRepository = auctionHistoryRepository;
    }
    
    [EnableQuery]
    [HttpGet]
    [Authorize]
    public IActionResult GetAllAuctionHistory() {
        var result = _auctionHistoryRepository.GetAll();
        return result.Any() ? Ok(result) : NotFound();
    }
    [EnableQuery]
    [HttpGet("get-by-id/{historyId}")]
    [Authorize]
    public IActionResult GetHistoryById( [FromODataUri] int historyId) {
        var result = _auctionHistoryRepository.GetById(historyId);
        return result.Any() ? Ok(result) : NotFound();
    }
    
}