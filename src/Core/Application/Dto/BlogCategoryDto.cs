using Domain.Entities;


namespace Application.Dto;

public class BlogCategoryDto : BaseDto
{
	public string Title { get; set; }
	public string Description { get; set; }

	public Guid UrlId { get; set; }
	public UrlRecordDto Url { get; set; }

	public Guid LanguageId { get; set; }
	public LanguageDto Language { get; set; }

	public ICollection<BlogDto> Blogs { get; set; }
}
