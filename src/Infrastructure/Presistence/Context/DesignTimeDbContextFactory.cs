using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Persistence.Context;


namespace Persistence.DesignTimeDbContextFactory;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=(local);Database=AoGen;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=true");

        return new DataContext(optionsBuilder.Options);
    }
}
