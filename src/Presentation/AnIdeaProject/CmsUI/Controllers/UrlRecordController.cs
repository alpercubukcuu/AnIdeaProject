using Application.BussinesLogic.UrlRecordBL.Commands;
using Application.BussinesLogic.UrlRecordBL.Queries;
using Application.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CmsUI.Controllers
{
    public class UrlRecordController : Controller
    {
        private readonly IMediator _mediator;
        public UrlRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new GetAllUrlRecordQuery { });
            if (res.IsSuccess) 
            { 
                List<UrlRecordDto> response = new List<UrlRecordDto>();
                return View(response);             
            }
            return View(res);
        }

        public IActionResult AddUrl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostUrl([FromBody] UrlRecord urlRecord)
        {
            var res = await _mediator.Send(new AddUrlRecordCommand
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                FullPath = urlRecord.FullPath,
                CreatedBy = 1,
                UpdatedAt = DateTime.Now,
                IsRoot = urlRecord.IsRoot,
                IsDeleted =false,
                Path = urlRecord.Path,
                ParentId = Guid.Empty,
                RootUrlId = Guid.Empty,
                UpdatedBy = 1

            });
            if (!res.IsSuccess) { return BadRequest("There was a problem adding it."); }
            return Ok(res);
        }
    }
}
