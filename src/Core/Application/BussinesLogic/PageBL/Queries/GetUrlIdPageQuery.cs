using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;

namespace Application.BussinesLogic.PageBL.Queries;

public class GetUrlIdPageQuery : IRequest<IResultData<PageDto>>
{
    public Guid UrlId { get; set; }
}
