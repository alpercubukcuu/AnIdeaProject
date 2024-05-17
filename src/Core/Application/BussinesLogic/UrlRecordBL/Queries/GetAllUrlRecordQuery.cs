using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;

namespace Application.BussinesLogic.UrlRecordBL.Queries;

public class GetAllUrlRecordQuery : IRequest<IResultData<IList<UrlRecordDto>>>
{   
}

