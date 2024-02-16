using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class PageCategories : BaseEntity
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    
}
