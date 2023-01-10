using Application.DTO;
using Application.DTO.Requests;
using Application.DTO.Response;

namespace Application.Services.Requests;

public interface IRequestService
{
    Task<Page<RequestDto>> Get(int entriesPerPage, int currentPage, string sort, string? query);
    Task<RequestDto> Create(CreateRequestDto createRequestDto);
    Task<RequestDto?> Update(UpdateRequestDto updateRequestDto);
    Task<bool> Delete(int id);
}