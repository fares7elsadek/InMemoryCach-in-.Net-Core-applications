using InMemoryCach.Data.Config;
using InMemoryCach.Models;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCach.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
{
   public DbSet<Driver> Drivers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DriverConfigurations).Assembly);
    }
}
