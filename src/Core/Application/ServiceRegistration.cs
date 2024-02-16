using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;


namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);
    }
}
