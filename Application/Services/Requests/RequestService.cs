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
            "id" => _context.Requests.OrderBy(r => r.Id),
            "-id" => _context.Requests.OrderByDescending(r => r.Id),
            _ => _context.Requests.OrderByDescending(r => r.Id)
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
        var lastRequestInCurrentYear = _context.Requests
            .Where(r => r.Receipt.Year == currentDate.Year)
            .OrderByDescending(r => r.Number).FirstOrDefault();
        var newRequest = _mapper.Map<CreateRequestDto, Request>(createRequestDto);
        newRequest.Number = lastRequestInCurrentYear is null ? 1 : lastRequestInCurrentYear.Number + 1;
        var request = await _context.Requests.AddAsync(newRequest);
        await _context.SaveChangesAsync();
        return _mapper.Map<Request, RequestDto>(request.Entity);
    }

    public async Task<RequestDto?> Update(UpdateRequestDto updateRequestDto)
    {
        var updatingRequest = await _context.Requests.FindAsync(updateRequestDto.Id);
        if (updatingRequest is null) return null;
        _mapper.Map(updateRequestDto, updatingRequest);
        await _context.SaveChangesAsync();
        return _mapper.Map<Request, RequestDto>(updatingRequest);
    }

    public async Task<bool> Delete(int id)
    {
        var deletingRequest = await _context.Requests.FindAsync(id);
        if (deletingRequest is null) return false;
        _context.Requests.Remove(deletingRequest);
        await _context.SaveChangesAsync();
        return true;
    }
}