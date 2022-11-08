using Application.DTO.Requests;
using Application.DTO.Response;

namespace Application.Services.Requests;

public interface IRequestService
{
    Task<IEnumerable<RequestDto>> Get(int limit, int page, string sort);
    Task<int> GetTotalCount();
    Task<RequestDto> Create(CreateRequestDto createRequestDto);
}