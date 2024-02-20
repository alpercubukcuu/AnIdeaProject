using Application.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.ServiceRegistration;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<DataContext>(opt => opt.UseMySQL(connectionString));

        serviceCollection.AddTransient<IPageCategoryRepository, PageCategoryRepository>();
        serviceCollection.AddTransient<IPageRepository, PageRepository>();
        serviceCollection.AddTransient<IUrlRecordRepository, UrlRecordRepository>();
		serviceCollection.AddTransient<IBlogRepository, BlogRepository>();
		serviceCollection.AddTransient<IBlogCategoryRepository, BlogCategoryRepository>();


	}

}
