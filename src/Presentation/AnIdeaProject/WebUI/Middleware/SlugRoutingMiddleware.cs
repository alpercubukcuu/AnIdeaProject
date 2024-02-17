namespace WebUI.Middleware;

public class SlugRoutingMiddleware
{
    private readonly RequestDelegate _next;

    public SlugRoutingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context /* diğer bağımlılıklarınızı buraya ekleyebilirsiniz, örneğin veritabanı servisi */)
    {
        var requestedPath = context.Request.Path.Value;

        if (!string.IsNullOrEmpty(requestedPath) && requestedPath != "/")
        {
            // Veritabanından slug'a göre route bilgisi çek
            // Örneğin: var routeInfo = await databaseService.GetRouteInfoBySlug(requestedPath);

            // Burada routeInfo'nun controller ve action isimlerini alıp kullanabilirsiniz
            // Örneğin: var controllerName = routeInfo.Controller; var actionName = routeInfo.Action;

            // Eğer bir route bilgisi bulunamazsa, hata yönetimi yapabilirsiniz.
            // Örneğin: context.Response.StatusCode = 404; return;

            // Route bilgisine göre yönlendirme yap
            // Örneğin: context.Request.Path = $"/{controllerName}/{actionName}";
        }

        // Sonraki middleware'e geç


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
