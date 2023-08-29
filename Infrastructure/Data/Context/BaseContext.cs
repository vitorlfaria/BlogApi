using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Context;

public class BaseContext : IdentityDbContext<User>
{
    public BaseContext(DbContextOptions<BaseContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // get the configuration from the app settings
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // define the database to use
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }
    
    public override int SaveChanges()
    {
        var entries = (from entry in ChangeTracker.Entries()
            where entry.State is EntityState.Added or EntityState.Modified
            select entry).ToList();

        foreach (var entityEntry in entries)
        {
            ((Entity)entityEntry.Entity).UpdatedAt = DateTime.Now;
            
            if (entityEntry.State == EntityState.Added)
            {
                ((Entity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }
        
        return base.SaveChanges();
    }
}