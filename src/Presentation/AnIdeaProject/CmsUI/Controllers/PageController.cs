using Application.BussinesLogic.UrlRecordBL.Commands;
using Application.BussinesLogic.UrlRecordBL.Handler;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CmsUI.Controllers
{
    public class PageController : Controller
    {
        private readonly IMediator _mediator;
        public PageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

      

        public async Task<IActionResult> AddPageCategory()
        {

            return Ok();
        }

        public async Task<IActionResult> AddPage()
        {

            return Ok();
        }
    }
}
