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
                if(!WebHelper.IsHomePage(requestedPath))
                {
                    requestedPath = WebHelper.GetLastSegment(requestedPath);
                }

                var urlData = await mediator.Send(new GetRouteInfoUrlRecordQuery() { Route = requestedPath });
                if(!urlData.IsSuccess) { await _next(context); }

                //var pageData = 
                // Kalan işlemleriniz...
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
