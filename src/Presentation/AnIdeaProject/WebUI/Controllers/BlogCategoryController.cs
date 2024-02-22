using Application.BussinesLogic.BlogBL.Queries;
using Application.BussinesLogic.BlogCategoryBL.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
	public class BlogCategoryController : Controller
	{
		private readonly IMediator _mediator;
		public BlogCategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IActionResult> Index(string languageId)
		{
            Guid LanguageId = Guid.Parse(languageId);
            var blogCategories = await _mediator.Send(new GetAllBlogCategoryQuery() { LanguageId = LanguageId });
			if (!blogCategories.IsSuccess) { return BadRequest(blogCategories.Message); }

			return View(blogCategories.Data);
		}

		public async Task<IActionResult> Detail(string urlId) 
		{
			BlogViewModel blogViewModel = new();

            Guid UrlId = Guid.Parse(urlId);
			var blogCategory = await _mediator.Send(new GetByUrlIdBlogCategoryQuery() { UrlId = UrlId });
            if (!blogCategory.IsSuccess) { return BadRequest(blogCategory.Message); }

			var blogs = await _mediator.Send(new GetByCategoryIdBlogQuery() { CategoryId = blogCategory.Data.Id });
            if (!blogs.IsSuccess) { return BadRequest(blogs.Message); }

			blogViewModel.BlogCategory = blogCategory.Data;
			blogViewModel.Blogs = blogs.Data;

            return View(blogViewModel);
		}
	}
}
