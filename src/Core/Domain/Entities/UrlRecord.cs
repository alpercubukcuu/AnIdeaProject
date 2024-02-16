using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UrlRecord : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }


    public string Slug { get; set; } 
    public Guid PageId { get; set; }
    public Pages Page { get; set; }

    public Guid? ParentId { get; set; }


    public string? RedirectUrl { get; set; } // Bu URL için bir yönlendirme varsa
    public int? RedirectType { get; set; } // 301, 302 gibi HTTP yönlendirme durum kodları
}
