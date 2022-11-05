using Application.DTO.Response;
using AutoMapper;
using Infrastructure;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Requests;

public class RequestService : IRequestService
{
    private readonly EleCrmContext _context;
    private readonly IMapper _mapper;

    public RequestService(EleCrmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RequestDto>> GetPage(int limit, int page)
    {
        var requests = await _context.Requests.Skip((page - 1) * limit).Take(limit).ToListAsync();
        return _mapper.Map<List<Request>, List<RequestDto>>(requests);
    }
    
    public async Task<int> GetTotalCount()
    {
        return await _context.Requests.CountAsync();
    }
}