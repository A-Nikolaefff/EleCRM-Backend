using Application.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EleCRM_Backend.Controllers;

[Route("api/requests")]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPage([FromQuery] int limit, [FromQuery] int page)
    {
        var response = await _requestService.GetPage(limit, page);
        var totalCount = await _requestService.GetTotalCount();
        Response.Headers.Add("X-Total-Count", totalCount.ToString());
        return Ok(response);
    }
}