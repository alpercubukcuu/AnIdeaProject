using Application.BussinesLogic.PageBL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(string urlId)
        {
            Guid UrlId = Guid.Parse(urlId);

            var pageData = await _mediator.Send(new GetUrlIdPageQuery() { UrlId = UrlId });
            if (!pageData.IsSuccess) { return BadRequest(pageData.Message); }

			return View(pageData.Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
