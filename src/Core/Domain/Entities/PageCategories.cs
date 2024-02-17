using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class PageCategories : BaseEntity
{
    [MaxLength(250)]
    [DisplayName("Başlık")]
    public string Title { get; set; }

    [MaxLength(500)]
    [DisplayName("Açıklama")]
    public string Description { get; set; }
    public string Slug { get; set; }
    public string? EntityName { get; set; }
    public byte PageType { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    
}
