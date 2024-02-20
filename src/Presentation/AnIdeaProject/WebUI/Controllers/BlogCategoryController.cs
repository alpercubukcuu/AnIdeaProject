using Application.BussinesLogic.BlogCategoryBL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class BlogCategoryController : Controller
	{
		private readonly IMediator _mediator;
		public BlogCategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var blogCategories = await _mediator.Send(new GetAllBlogCategoryQuery() { LanguageId = Guid.Empty });
			if (!blogCategories.IsSuccess) { return BadRequest(blogCategories.Message); }

			return View();
		}

		public IActionResult Detail() 
		{
			return View();
		}
	}
}
