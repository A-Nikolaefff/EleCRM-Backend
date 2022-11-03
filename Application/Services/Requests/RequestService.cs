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

    public async Task<IEnumerable<RequestDto>> GetAll()
    {
        var requests = await _context.Requests.ToListAsync();
        return _mapper.Map<List<Request>, List<RequestDto>>(requests);
    }
}