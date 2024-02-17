using Application.Interface.Repositories;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories;

public class PageRepository : Repository<Pages>, IPageRepository
{
    public PageRepository(DataContext context) : base(context)
    {

    }

}
