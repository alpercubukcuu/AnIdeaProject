using Application.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapping.PagesProfile;

public class PageProfile : Profile
{
    public PageProfile()
    {
        CreateMap<Pages, PageDto>().ReverseMap();
        CreateMap<PageDto, Pages>().ReverseMap();
        CreateMap<IQueryable<PageDto>, IQueryable<Pages>>().ReverseMap();
    }
}
