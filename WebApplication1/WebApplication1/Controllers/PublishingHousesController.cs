using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishingHousesController(PublishingHouseService publishingHouseService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PublishingHouse>>> GetPublishingHouses([FromQuery] string country, [FromQuery] string city)
    {
        var result = await publishingHouseService.GetPublishingHousesAsync(country, city);
        return Ok(result);
    }
}