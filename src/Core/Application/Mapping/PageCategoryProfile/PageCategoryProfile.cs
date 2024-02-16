using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.PageCategoryProfile
{
    public class PageCategoryProfile : Profile
    {
        public PageCategoryProfile()
        {
            CreateMap<PageCategories, PageCategoryDto>().ReverseMap();
            CreateMap<PageCategoryDto, PageCategories>().ReverseMap();
            CreateMap<IQueryable<PageCategoryDto>, IQueryable<PageCategories>>().ReverseMap();
        }
    }
}
