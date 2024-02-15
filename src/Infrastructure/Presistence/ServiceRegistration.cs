using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Context;

namespace Presistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<DataContext>(opt => opt.UseMySQL(connectionString));


    }

}
