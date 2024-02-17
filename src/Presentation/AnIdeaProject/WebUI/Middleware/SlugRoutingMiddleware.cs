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
                    context.Response.StatusCode = 404; // Not Found
                    return; // Durum başarısızsa, burada işlemi durdurun.
                }

                var pageData = await mediator.Send(new GetUrlIdPageQuery() { UrlId = urlData.Data.Id });
                if (!pageData.IsSuccess)
                {
                    context.Response.StatusCode = 404; // Not Found
                    return; // Durum başarısızsa, burada işlemi durdurun.
                }

                var pageCategory = await mediator.Send(new GetByIdPageCategoriesQuery() { PageCategoryId = pageData.Data.CategoryId });
                if (!pageCategory.IsSuccess)
                {
                    context.Response.StatusCode = 404; // Not Found
                    return; // Durum başarısızsa, burada işlemi durdurun.
                }

                // Burada pageCategory ile ilgili yapmanız gereken işlemler varsa ekleyin
                // Örneğin, pageCategory verisine bağlı olarak bir işlem yapmak isteyebilirsiniz.

                // İsteği MVC yönlendirme yapısına göre yeniden yaz
                var controllerName = pageCategory.Data.ControllerName; // Varsayalım ki bu değer "Home"
                var actionName = pageCategory.Data.ActionName; // Varsayalım ki bu değer "Index"

                // İsteği yeniden yaz
                var newPath = $"/{controllerName}/{actionName}";
                context.Request.Path = newPath;
                // Query string'i koruyun (varsa)
                context.Request.QueryString = QueryString.Create(context.Request.Query);

                // MVC pipeline'ını çalıştırın
                await _next(context);
                return;
            }
        }

        // Eğer bir üstteki if koşullarına girilmediyse, normal akışa devam edin
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
