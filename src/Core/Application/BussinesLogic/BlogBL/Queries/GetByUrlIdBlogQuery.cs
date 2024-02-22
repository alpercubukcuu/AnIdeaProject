using Application.Dto;
using Application.Interface.ResutRepository;
using Domain.Entities;
using MediatR;


namespace Application.BussinesLogic.BlogBL.Queries;

public class GetByUrlIdBlogQuery : IRequest<IResultData<BlogDto>>
{
    public Guid UrlId { get; set; }
}
