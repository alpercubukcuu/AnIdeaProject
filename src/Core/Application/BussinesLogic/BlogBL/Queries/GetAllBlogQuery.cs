using Application.Dto;
using Application.Interface.ResutRepository;
using Domain.Entities;
using MediatR;


namespace Application.BussinesLogic.BlogBL.Queries;

public class GetAllBlogQuery : IRequest<IResultData<List<BlogDto>>>
{
    public Guid LanguageId { get; set; }
}
