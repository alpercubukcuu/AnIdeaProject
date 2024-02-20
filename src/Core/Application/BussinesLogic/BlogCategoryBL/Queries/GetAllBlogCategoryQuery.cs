using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;


namespace Application.BussinesLogic.BlogCategoryBL.Queries;

public class GetAllBlogCategoryQuery : IRequest<IResultData<List<BlogCategoryDto>>>
{
    public Guid LanguageId { get; set; }
}
