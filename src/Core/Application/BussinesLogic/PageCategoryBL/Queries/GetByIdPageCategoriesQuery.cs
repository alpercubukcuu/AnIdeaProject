using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;


namespace Application.BussinesLogic.PageCategoryBL.Queries;

public class GetByIdPageCategoriesQuery : IRequest<IResultData<PageCategoryDto>>
{
    public Guid PageCategoryId { get; set; }
}
