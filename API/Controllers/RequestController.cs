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
    public async Task<IActionResult> GetPage(int entriesPerPage, int currentPage, string sort, string? query)
    {
        var requestPage = await _requestService.Get(entriesPerPage, currentPage, sort, query);
        Response.Headers.Add("X-Total-Count", requestPage.TotalCount.ToString());
        return Ok(requestPage.Entries);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestDto createRequestDto)
    {
        var newRequest = await _requestService.Create(createRequestDto);
        return Ok(newRequest);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRequestDto updateRequestDto)
    {
        var updatedRequest = await _requestService.Update(updateRequestDto);
        if (updatedRequest is null) return new NotFoundResult();
        return Ok(updatedRequest);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var isRequestDeleted = await _requestService.Delete(id);
        return isRequestDeleted ? Ok() : new NotFoundResult();
    }
}