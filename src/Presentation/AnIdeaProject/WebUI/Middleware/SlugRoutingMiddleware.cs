using Application.BussinesLogic.PageBL.Queries;
using Application.BussinesLogic.PageCategoryBL.Queries;
using Application.BussinesLogic.UrlRecordBL.Queries;
using MediatR;
using WebUI.Helper;

namespace WebUI.Middleware;

public class SlugRoutingMiddleware
{
    private readonly RequestDelegate _next;

    public SlugRoutingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        using (var scope = context.RequestServices.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var requestedPath = context.Request.Path.Value;

            if (!string.IsNullOrEmpty(requestedPath))
            {
                if (!WebHelper.IsHomePage(requestedPath))
                {
                    requestedPath = WebHelper.GetLastSegment(requestedPath);
                }

                var urlData = await mediator.Send(new GetRouteInfoUrlRecordQuery() { Route = requestedPath });
                if (!urlData.IsSuccess)
                {
                    context.Response.StatusCode = 404; 
                    return; 
                }

                var pageData = await mediator.Send(new GetUrlIdPageQuery() { UrlId = urlData.Data.Id });
                if (!pageData.IsSuccess)
                {
                    context.Response.StatusCode = 404;
                    return; 
                }

                var pageCategory = await mediator.Send(new GetByIdPageCategoriesQuery() { PageCategoryId = pageData.Data.CategoryId });
                if (!pageCategory.IsSuccess)
                {
                    context.Response.StatusCode = 404; 
                    return; 
                }
               
                var controllerName = pageCategory.Data.ControllerName; 
                var actionName = pageCategory.Data.ActionName; 

               
                var newPath = $"/{controllerName}/{actionName}";
                context.Request.Path = newPath;
                
                context.Request.QueryString = QueryString.Create(context.Request.Query);

                
                await _next(context);
                return;
            }
        }

       
        await _next(context);
    }
}

public static class SlugRoutingMiddlewareExtensions
{
    public static IApplicationBuilder UseSlugRouting(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SlugRoutingMiddleware>();
    }
}
