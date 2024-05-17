using Application.BussinesLogic.UrlRecordBL.Queries;
using Application.Dto;
using Application.Interface.Repositories;
using Application.Interface.ResutRepository;
using AutoMapper;
using MediatR;


namespace Application.BussinesLogic.UrlRecordBL.Handler;

public class GetAllUrlRecordHandler : IRequestHandler<GetAllUrlRecordQuery, IResultData<IList<UrlRecordDto>>>
{
    private readonly IUrlRecordRepository _urlRecordRepository;
    private readonly IMapper _mapper;
    public GetAllUrlRecordHandler(IUrlRecordRepository urlRecordRepository, IMapper mapper)
    {
        _urlRecordRepository = urlRecordRepository;
        _mapper = mapper;
    }
    public async Task<IResultData<IList<UrlRecordDto>>> Handle(GetAllUrlRecordQuery request, CancellationToken cancellationToken)
    {
        IResultData<IList<UrlRecordDto>> result = new ResultData<IList<UrlRecordDto>>();

        var urlData = _urlRecordRepository.GetAll(predicate: d => d.IsDeleted == false);
        if (urlData.Count() !> 0) { result.IsSuccess = false; result.Message = "Didn't find data about route!"; return result; }

		var map = _mapper.Map<IList<UrlRecordDto>>(urlData);	

        result.IsSuccess = true;
        result.Message = "Success";
        result.SetData(map);

        return result;
    }
}
