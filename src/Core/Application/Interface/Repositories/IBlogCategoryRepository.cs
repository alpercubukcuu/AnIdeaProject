using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repositories;

public interface IBlogCategoryRepository : IRepository<BlogCategories>
{
}
