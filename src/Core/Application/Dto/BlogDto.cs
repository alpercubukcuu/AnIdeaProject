using Domain.Entities;


namespace Application.Dto;

public class BlogDto : BaseDto
{
	public string Title { get; set; }
	public string SubTitle { get; set; }
	public string Content { get; set; }
	public string? ImagePath { get; set; }


	public Guid LanguageId { get; set; }
	public LanguageDto Language { get; set; }

	public Guid UrlId { get; set; }
	public UrlRecordDto Url { get; set; }

	public string? MetaKeywords { get; set; }
	public string? MetaDescription { get; set; }

}
