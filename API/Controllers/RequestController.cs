using Application.DTO.Requests;
using Application.Services.Requests;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> GetPage([FromQuery] int limit, [FromQuery] int page, [FromQuery] string sort)
    {
        var response = await _requestService.Get(limit, page, sort);
        var totalCount = await _requestService.GetTotalCount();
        Response.Headers.Add("X-Total-Count", totalCount.ToString());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestDto createRequestDto)
    {
        var response = await _requestService.Create(createRequestDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRequestDto updateRequestDto)
    {
        var response = await _requestService.Update(updateRequestDto);
        if (response is null) return new NotFoundResult();
        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var isRequestDeleted = await _requestService.Delete(id);
        return isRequestDeleted ? Ok() : new NotFoundResult();
    }
}