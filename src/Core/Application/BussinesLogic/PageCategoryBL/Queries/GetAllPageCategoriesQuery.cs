using Application.Dto;
using Application.Interface.ResutRepository;
using MediatR;


namespace Application.BussinesLogic.PageCategoryBL.Queries;

public class GetAllPageCategoriesQuery : IRequest<IResultData<List<PageCategoryDto>>>
{
}
