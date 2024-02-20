using Application.Interface.Repositories;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories;

public class BlogCategoryRepository : Repository<BlogCategories> , IBlogCategoryRepository
{
    public BlogCategoryRepository(DataContext context) : base(context)
	{
        
    }
}
