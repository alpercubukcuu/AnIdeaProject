using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping.PageCategoryProfile;

public class PageCategoryProfile : Profile
{
    public PageCategoryProfile()
    {
        CreateMap<PageCategories, PageCategoryDto>().ReverseMap();
        CreateMap<PageCategoryDto, PageCategories>().ReverseMap();
        CreateMap<IQueryable<PageCategoryDto>, IQueryable<PageCategories>>().ReverseMap();
    }
}
