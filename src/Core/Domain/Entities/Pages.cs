using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Domain.Entities;

public class Pages : BaseEntity
{
    [Required]
    [StringLength(250)]
    [DisplayName("Başlık")]
    public string Title { get; set; }

    [StringLength(500)]
    [DisplayName("Açıklama")]
    public string Description { get; set; }
    public string Slug { get; set; }

    public Guid CategoryId { get; set; } 
    public PageCategories Category { get; set; }

    public Guid UrlId { get; set; }
    [ForeignKey(nameof(UrlId))]
    public UrlRecord Url { get; set; }


    public Guid LanguageId { get; set; }
    public Languages Language { get; set; }

    public bool IsActive { get; set; }
    public DateTime? PublishedDate { get; set; }

    // SEO için ekstra özellikler
    public string? MetaKeywords { get; set; }
    public string? MetaDescription { get; set; }

  
    public string LanguageCode { get; set; }
}
