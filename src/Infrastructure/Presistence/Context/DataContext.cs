﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }


    public DbSet<PageCategories> PageCategories { get; set; }
    public DbSet<Pages> Pages { get; set; }
	public DbSet<Blogs> Blogs { get; set; }
	public DbSet<BlogCategories> BlogCtegories { get; set; }
	public DbSet<UrlRecord> UrlRecord { get; set; }
    public DbSet<Languages> Languages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}
