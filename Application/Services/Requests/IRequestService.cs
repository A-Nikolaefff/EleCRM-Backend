using Application.DTO.Response;

namespace Application.Services.Requests;

public interface IRequestService
{
    Task<IEnumerable<RequestDto>> GetPage(int limit, int page);
    Task<int> GetTotalCount();
}