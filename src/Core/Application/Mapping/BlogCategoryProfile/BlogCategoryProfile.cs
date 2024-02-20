using Application.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapping.BlogCategoryProfile;

public class BlogCategoryProfile : Profile
{
    public BlogCategoryProfile()
    {
		CreateMap<BlogCategories, BlogCategoryDto>().ReverseMap();
		CreateMap<BlogCategoryDto, BlogCategories>().ReverseMap();
		CreateMap<IQueryable<BlogCategoryDto>, IQueryable<BlogCategories>>().ReverseMap();
	}

}
