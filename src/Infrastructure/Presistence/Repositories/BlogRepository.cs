using Application.Interface.Repositories;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories;

public class BlogRepository : Repository<Blogs> , IBlogRepository
{
    public BlogRepository(DataContext context) : base(context)
	{
        
    }
}
