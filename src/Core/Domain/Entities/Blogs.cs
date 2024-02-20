using Domain.Common;
using System.ComponentModel;


namespace Domain.Entities;

public class Blogs : BaseEntity
{

    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Content { get; set; }
	public string? ImagePath { get; set; }

	public Guid LanguageId { get; set; }
    public Languages Language { get; set; }

    public Guid UrlId { get; set; }
    public UrlRecord Url { get; set; }

	public Guid BlogCategoryId { get; set; }	
	public BlogCategories BlogCategory { get; set; }

	public string? MetaKeywords { get; set; }
	public string? MetaDescription { get; set; }
}
