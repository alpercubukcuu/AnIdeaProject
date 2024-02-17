using Application.BussinesLogic.UrlRecordBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;


namespace Application.BussinesLogic.UrlRecordBL.Handler;

public class GetRouteInfoUrlRecordHandler : IRequestHandler<GetRouteInfoUrlRecordQuery, IResultData<UrlRecordDto>>
{
    private readonly IUrlRecordRepository _urlRecordRepository;
    private readonly IMapper _mapper;
    public GetRouteInfoUrlRecordHandler(IUrlRecordRepository urlRecordRepository, IMapper mapper)
    {
        _urlRecordRepository = urlRecordRepository;
        _mapper = mapper;
    }
    public async Task<IResultData<UrlRecordDto>> Handle(GetRouteInfoUrlRecordQuery request, CancellationToken cancellationToken)
    {
        IResultData<UrlRecordDto> result = new ResultData<UrlRecordDto>();

        var urlData = _urlRecordRepository.GetSingle(predicate: d => d.IsDeleted == false && d.Path == request.Route);
        if (urlData == null) { result.IsSuccess = false; result.Message = "Didn't find data about route!"; return result; }

        if(urlData.ParentId is not null) 
        {
           var relatedUrlData = _urlRecordRepository.GetSingle(predicate: d => d.IsDeleted == false && d.Id == urlData.ParentId);
            if(relatedUrlData is not null)
            {
                urlData.Path = $"{relatedUrlData.Path}/{urlData.Path}";
            }
        }

        var map = _mapper.Map<UrlRecordDto>(urlData);
        result.IsSuccess = true;
        result.Message = "Success";
        result.SetData(map);

        return result;
    }
}
