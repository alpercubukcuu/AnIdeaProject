using Domain.Common;



namespace Domain.Entities;

public class UrlRecord : BaseEntity
{
    public string Path { get; set; }
    public string FullPath { get; set; }
    public Guid? ParentId { get; set; }
    public bool? IsRoot { get; set; }


    public string? RedirectUrl { get; set; } // Bu URL için bir yönlendirme varsa
    public int? RedirectType { get; set; } // 301, 302 gibi HTTP yönlendirme durum kodları
}
