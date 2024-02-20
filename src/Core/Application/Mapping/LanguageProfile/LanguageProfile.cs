using Application.Dto;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapping.LanguageProfile;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
		CreateMap<Languages, LanguageDto>().ReverseMap();
		CreateMap<LanguageDto, Languages>().ReverseMap();
		CreateMap<IQueryable<LanguageDto>, IQueryable<Languages>>().ReverseMap();
	}
}
