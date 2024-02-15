using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Presistence.Context;


namespace OnionArcExample.Persistence.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {            
        string connectionString = "Server=68.178.246.186;Port=3306;Database=AnIdeaProject;Uid=acteam;Pwd=t6qRGh4fshh5sZH;";
        DbContextOptionsBuilder<DataContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseMySQL(connectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}
