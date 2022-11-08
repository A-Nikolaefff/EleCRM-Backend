using Application.DTO.Requests;
using Application.DTO.Response;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        AllowNullCollections = true;
        CreateMap<Request, RequestDto>();
        CreateMap<CreateRequestDto, Request>();
    }
}