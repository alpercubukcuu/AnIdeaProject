using Application.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapping.UrlRecordProfile;

public class UrlRecordProfile : Profile
{
    public UrlRecordProfile()
    {
        CreateMap<UrlRecord, UrlRecordDto>().ReverseMap();
        CreateMap<UrlRecordDto, UrlRecord>().ReverseMap();
        CreateMap<IQueryable<UrlRecordDto>, IQueryable<UrlRecord>>().ReverseMap();
    }
}
