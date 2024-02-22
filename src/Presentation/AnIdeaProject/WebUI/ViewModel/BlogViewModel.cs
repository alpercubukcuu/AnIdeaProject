using Application.Dto;

namespace WebUI.ViewModel;

public class BlogViewModel
{
    public BlogCategoryDto BlogCategory { get; set; }

    public List<BlogDto> Blogs { get; set; }
}
