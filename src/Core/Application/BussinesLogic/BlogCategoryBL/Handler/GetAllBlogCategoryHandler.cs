using Application.BussinesLogic.BlogCategoryBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.BussinesLogic.BlogCategoryBL.Handler;

public class GetAllBlogCategoryHandler : IRequestHandler<GetAllBlogCategoryQuery, IResultData<List<BlogCategoryDto>>>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly IMapper _mapper;
	public GetAllBlogCategoryHandler(IBlogCategoryRepository blogCategoryRepository, IMapper mapper)
	{
		_blogCategoryRepository = blogCategoryRepository;
		_mapper = mapper;
	}

	public async Task<IResultData<List<BlogCategoryDto>>> Handle(GetAllBlogCategoryQuery request, CancellationToken cancellationToken)
	{
		IResultData<List<BlogCategoryDto>> result = new ResultData<List<BlogCategoryDto>>();

		var blogCategories =  _blogCategoryRepository.GetAll(predicate: d=>d.IsDeleted == false && d.LanguageId == request.LanguageId, include: p => p.Include(p=>p.Blogs).Include(p=>p.Url));
		if (blogCategories == null) { result.IsSuccess = false; result.Message = "Didn't find datas"; return result; }

		var map = _mapper.Map<List<BlogCategoryDto>>(blogCategories);
		result.IsSuccess = true;
		result.Message = "Success";
		result.SetData(map);

		return result;
	}
}
