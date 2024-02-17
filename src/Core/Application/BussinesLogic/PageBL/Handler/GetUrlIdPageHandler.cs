using Application.BussinesLogic.PageBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;


namespace Application.BussinesLogic.PageBL.Handler;

public class GetUrlIdPageHandler : IRequestHandler<GetUrlIdPageQuery, IResultData<PageDto>>
{
    private readonly IPageRepository _pageRepository;
    private readonly IMapper _mapper;
    public GetUrlIdPageHandler(IPageRepository pageRepository, IMapper mapper)
    {
        _pageRepository = pageRepository;
        _mapper = mapper;
    }

    public async Task<IResultData<PageDto>> Handle(GetUrlIdPageQuery request, CancellationToken cancellationToken)
    {
        IResultData<PageDto> result = new ResultData<PageDto>();

        var pageData = _pageRepository.GetSingle(predicate: d => d.IsDeleted == false && d.UrlId == request.UrlId);
        if (pageData == null) { result.IsSuccess = false; result.Message = "Didn't find data about route!"; return result; }


        var map = _mapper.Map<PageDto>(pageData);
        result.IsSuccess = true;
        result.Message = "Success";
        result.SetData(map);

        return result;
    }
}
