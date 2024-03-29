﻿using Application.BussinesLogic.PageCategoryBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;


namespace Application.BussinesLogic.PageCategoryBL.Handler;

public class GetAllPageCategoriesQueryHandler : IRequestHandler<GetAllPageCategoriesQuery, IResultData<List<PageCategoryDto>>>
{
    private readonly IPageCategoryRepository _pageCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllPageCategoriesQueryHandler(IPageCategoryRepository pageCategoryRepository, IMapper mapper)
    {
        _pageCategoryRepository = pageCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IResultData<List<PageCategoryDto>>> Handle(GetAllPageCategoriesQuery request, CancellationToken cancellationToken)
    {
        IResultData<List<PageCategoryDto>> result = new ResultData<List<PageCategoryDto>>();

        var categories = await _pageCategoryRepository.GetAllAsync();
        if (categories == null) { result.IsSuccess = false; result.Message = "Didn't find datas"; return result; }

        var map = _mapper.Map<List<PageCategoryDto>>(categories);
        result.IsSuccess = true;
        result.Message = "Success";
        result.SetData(map);

        return result;
    }
}
