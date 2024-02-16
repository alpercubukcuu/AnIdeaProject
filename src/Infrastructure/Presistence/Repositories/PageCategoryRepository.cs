using Application.Interface.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class PageCategoryRepository : Repository<PageCategories> , IPageCategoryRepository
{
    public PageCategoryRepository(DataContext context) : base(context)
    {
        
    }
  
}
