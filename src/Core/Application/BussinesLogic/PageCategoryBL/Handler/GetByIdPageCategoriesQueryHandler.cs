using Application.BussinesLogic.PageCategoryBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;


namespace Application.BussinesLogic.PageCategoryBL.Handler;

public class GetByIdPageCategoriesHandler : IRequestHandler<GetByIdPageCategoriesQuery, IResultData<PageCategoryDto>>
{
    private readonly IPageCategoryRepository _pageCategoryRepository;
    private readonly IMapper _mapper;

    public GetByIdPageCategoriesHandler(IPageCategoryRepository pageCategoryRepository, IMapper mapper)
    {
        _pageCategoryRepository = pageCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IResultData<PageCategoryDto>> Handle(GetByIdPageCategoriesQuery request, CancellationToken cancellationToken)
    {
        IResultData<PageCategoryDto> result = new ResultData<PageCategoryDto>();

        var categories =  _pageCategoryRepository.GetSingle(predicate: d => d.IsDeleted == false && d.Id == request.PageCategoryId);
        if (categories == null) { result.IsSuccess = false; result.Message = "Didn't find datas"; return result; }

        var map = _mapper.Map<PageCategoryDto>(categories);
        result.IsSuccess = true;
        result.Message = "Success";
        result.SetData(map);

        return result;
    }
}
