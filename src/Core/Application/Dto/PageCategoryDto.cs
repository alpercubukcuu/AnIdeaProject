using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto;

public class PageCategoryDto: BaseDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public Guid ParentId { get; set; }
}
