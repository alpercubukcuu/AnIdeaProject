using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context;

public class DataContext : DbContext
{
    
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
   
    public DbSet<PageCategories> PageCategories { get; set; }
    public DbSet<Pages> Pages { get; set; }

    //public DbSet<Blogs> Blogs { get; set; }
    //public DbSet<BlogCategories> BlogCategories { get; set; }
    public DbSet<UrlRecord> UrlRecord { get; set; }
    public DbSet<Languages> Languages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        
    }
}
