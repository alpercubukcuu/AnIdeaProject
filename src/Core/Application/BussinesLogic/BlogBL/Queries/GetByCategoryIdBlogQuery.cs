using Application.Dto;
using Application.Interface.ResutRepository;
using Domain.Entities;
using MediatR;


namespace Application.BussinesLogic.BlogBL.Queries;

public class GetByCategoryIdBlogQuery : IRequest<IResultData<List<BlogDto>>>
{
    public Guid CategoryId { get; set; }
}
