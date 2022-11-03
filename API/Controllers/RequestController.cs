using Application.Services.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EleCRM_Backend.Controllers;

[Route("api/requests")]
public class RequestController : Controller
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _requestService.GetAll();
        return Ok(response);
    }
}