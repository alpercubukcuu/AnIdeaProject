using Application.BussinesLogic.PageBL.Queries;
using Application.BussinesLogic.UrlRecordBL.Queries;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Server.IIS;
using WebUI.Helper;

namespace WebUI.Infrastructure.Routing
{
    public class MyDynamicRouteHandler : DynamicRouteValueTransformer
    {
        private readonly IMediator _mediator;
        public MyDynamicRouteHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            var requestedPath = httpContext.Request.Path.Value;
            var controllerName = string.Empty;
            var actionName = string.Empty;

            if (!string.IsNullOrEmpty(requestedPath))
            {
                if (!WebHelper.IsHomePage(requestedPath))
                {
                    requestedPath = WebHelper.GetLastSegment(requestedPath);
                }

                var urlData = await _mediator.Send(new GetRouteInfoUrlRecordQuery() { Route = requestedPath });
                if (!urlData.IsSuccess)
                {
                    values["controller"] = "Error";
                    values["action"] = "UrlError";
                    return values;
                }

                var pageData = await _mediator.Send(new GetUrlIdPageQuery() { UrlId = urlData.Data.Id });
                if (!pageData.IsSuccess)
                {
                    values["controller"] = "Error";
                    values["action"] = "PageError";
                    return values;
                }


                 controllerName = pageData.Data.Category.ControllerName;
                 actionName = pageData.Data.Category.ActionName;

                values["controller"] = controllerName;
                values["action"] = actionName;

                

            }
            else
            {
                values["controller"] = "Home";
                values["action"] = "Error";
            }

            return values;
        }
    }
}
