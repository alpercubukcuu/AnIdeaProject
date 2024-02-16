using Domain.Common;


namespace Domain.Entities;

public class Pages : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Slug { get; set; }

    public Guid CategoryId { get; set; } 
    public PageCategories Category { get; set; }     

    public bool IsActive { get; set; }
    public DateTime? PublishedDate { get; set; }

    // SEO için ekstra özellikler
    public string? MetaKeywords { get; set; }
    public string? MetaDescription { get; set; }

  
    public string LanguageCode { get; set; }
}
