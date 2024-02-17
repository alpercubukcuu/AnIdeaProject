using Application.Interface.Repositories;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories;


public class PageCategoryRepository : Repository<PageCategories>, IPageCategoryRepository
{
    public PageCategoryRepository(DataContext context) : base(context)
    {

    }

}