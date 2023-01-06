using Application.DTO.Requests;
using Application.DTO.Response;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application;

public class RequestMappingProfile : Profile
{
    public RequestMappingProfile()
    {
        AllowNullCollections = true;
        CreateMap<Request, RequestDto>();
        CreateMap<CreateRequestDto, Request>();
        CreateMap<UpdateRequestDto, Request>()
            .ForSourceMember(source => source.Id, 
                config => config.DoNotValidate());
    }
}