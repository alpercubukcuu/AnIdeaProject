using Application.BussinesLogic.BlogBL.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class BlogController : Controller
{
    private readonly IMediator _mediator;
    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IActionResult> Index(string languageId)
    {
        Guid LanguageId = Guid.Parse(languageId);
        var blogs = await _mediator.Send(new GetAllBlogQuery() { LanguageId = LanguageId });
        if (!blogs.IsSuccess) { return BadRequest(blogs.Message); }

        return View(blogs.Data);
    }

    public async Task<IActionResult> Detail(string urlId)
    {
        Guid UrlId = Guid.Parse(urlId);
        var blog = await _mediator.Send(new GetByUrlIdBlogQuery() { UrlId = UrlId });
        if (!blog.IsSuccess) { return BadRequest(blog.Message); }

        return View(blog.Data);
    }
}
