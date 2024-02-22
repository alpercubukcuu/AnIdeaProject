using Application.BussinesLogic.BlogCategoryBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.BussinesLogic.BlogCategoryBL.Handler;

public class GetByUrlIdBlogCategoryHandler : IRequestHandler<GetByUrlIdBlogCategoryQuery, IResultData<BlogCategoryDto>>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly IMapper _mapper;
	public GetByUrlIdBlogCategoryHandler(IBlogCategoryRepository blogCategoryRepository, IMapper mapper)
	{
		_blogCategoryRepository = blogCategoryRepository;
		_mapper = mapper;
	}

	public async Task<IResultData<BlogCategoryDto>> Handle(GetByUrlIdBlogCategoryQuery request, CancellationToken cancellationToken)
	{
		IResultData<BlogCategoryDto> result = new ResultData<BlogCategoryDto>();

		var blogCategories =  _blogCategoryRepository.GetSingle(predicate: d=>d.IsDeleted == false && d.UrlId == request.UrlId, include: p => p.Include(p=>p.Url).Include(p=>p.Language));
		if (blogCategories == null) { result.IsSuccess = false; result.Message = "Didn't find datas"; return result; }

		var map = _mapper.Map<BlogCategoryDto>(blogCategories);
		result.IsSuccess = true;
		result.Message = "Success";
		result.SetData(map);

		return result;
	}
}
