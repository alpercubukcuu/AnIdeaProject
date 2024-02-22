using Application.BussinesLogic.BlogBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.BussinesLogic.BlogBL.Handler;

public class GetByUrlIdBlogHandler : IRequestHandler<GetByUrlIdBlogQuery, IResultData<BlogDto>>
{
    private readonly IBlogRepository _blogRepository;
	private readonly IMapper _mapper;
	public GetByUrlIdBlogHandler(IBlogRepository blogRepository, IMapper mapper)
	{
		_blogRepository = blogRepository;
		_mapper = mapper;
	}

	public async Task<IResultData<BlogDto>> Handle(GetByUrlIdBlogQuery request, CancellationToken cancellationToken)
	{
		IResultData<BlogDto> result = new ResultData<BlogDto>();

		var blogs =  _blogRepository.GetSingle( predicate: p => p.IsDeleted == false && p.UrlId == request.UrlId,include: p => p.Include(d => d.Url).Include(d => d.Language));
		if (blogs == null) { result.IsSuccess = false; result.Message = "Didn't find datas"; return result; }

		var map = _mapper.Map<BlogDto>(blogs);
		result.IsSuccess = true;
		result.Message = "Success";
		result.SetData(map);

		return result;
	}
}
