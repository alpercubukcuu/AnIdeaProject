using Application.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapping.BlogProfile;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
		CreateMap<Blogs, BlogDto>().ReverseMap();
		CreateMap<BlogDto, Blogs>().ReverseMap();
		CreateMap<IQueryable<BlogDto>, IQueryable<Blogs>>().ReverseMap();
	}
}
