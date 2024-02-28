using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Persistence.Context;


namespace Persistence.DesignTimeDbContextFactory;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    private readonly DatabaseSettings _dbSettings;
    public DesignTimeDbContextFactory(IOptions<DatabaseSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public DataContext CreateDbContext(string[] args)
    {            
        string connectionString = _dbSettings.Mysql;
        DbContextOptionsBuilder<DataContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseMySQL(connectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}
