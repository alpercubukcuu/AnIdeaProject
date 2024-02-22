using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;


namespace Application.BussinesLogic.BlogCategoryBL.Queries;

public class GetByUrlIdBlogCategoryQuery : IRequest<IResultData<BlogCategoryDto>>
{
    public Guid UrlId { get; set; }
}
