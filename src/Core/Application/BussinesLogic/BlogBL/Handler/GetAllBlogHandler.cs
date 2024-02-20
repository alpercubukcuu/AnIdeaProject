using Application.BussinesLogic.BlogBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;


namespace Application.BussinesLogic.BlogBL.Handler;

public class GetAllBlogHandler : IRequestHandler<GetAllBlogQuery, IResultData<List<BlogDto>>>
{
    private readonly IBlogRepository _blogRepository;
	private readonly IMapper _mapper;
	public GetAllBlogHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		_blogRepository = blogRepository;
		_mapper = mapper;
	}

	public async Task<IResultData<List<BlogDto>>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
	{
		IResultData<List<BlogDto>> result = new ResultData<List<BlogDto>>();

		var blogs =  _blogRepository.GetAll( predicate: p => p.IsDeleted == false && p.LanguageId == request.LanguageId);
		if (blogs == null) { result.IsSuccess = false; result.Message = "Didn't find datas"; return result; }

		var map = _mapper.Map<List<BlogDto>>(blogs);
		result.IsSuccess = true;
		result.Message = "Success";
		result.SetData(map);

		return result;
	}
}
