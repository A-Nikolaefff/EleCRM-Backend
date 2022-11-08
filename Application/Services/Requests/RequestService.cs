using System.Diagnostics;
using Application.DTO.Requests;
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

    public async Task<IEnumerable<RequestDto>> Get(int limit, int page, string sort)
    {
        IQueryable<Request> orderedRequests = sort switch
        {
            "number" => _context.Requests.OrderBy(r => r.Number),
            "-number" => _context.Requests.OrderByDescending(r => r.Number),
            _ => _context.Requests.OrderBy(r => r.Number)
        };

        var requestPage = await orderedRequests.Skip((page - 1) * limit).Take(limit)
            .ToListAsync();
        return _mapper.Map<List<Request>, List<RequestDto>>(requestPage);
    }
    
    public async Task<int> GetTotalCount()
    {
        return await _context.Requests.CountAsync();
    }

    public async Task<RequestDto> Create(CreateRequestDto createRequestDto)
    {
        var currentDate = DateTime.Today;
        var lastRequest = _context.Requests
            .Where(r => r.ReceiptDate.Year == currentDate.Year)
            .OrderByDescending(r => r.Number).FirstOrDefault();
        var requestData = _mapper.Map<CreateRequestDto, Request>(createRequestDto);
        requestData.Number = lastRequest is not null ? lastRequest.Number + 1 : 1;
        var request = await _context.Requests.AddAsync(requestData);
        await _context.SaveChangesAsync();
        return _mapper.Map<Request, RequestDto>(request.Entity);
    }
}