using Application.DTO.Response;

namespace Application.Services.Requests;

public interface IRequestService
{
    Task<IEnumerable<RequestDto>> GetAll();
}