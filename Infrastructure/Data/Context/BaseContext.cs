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
            where entry.State == EntityState.Added || entry.State == EntityState.Deleted || entry.State == EntityState.Modified
            select entry).ToList();

        try
        {
            base.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            string textError = string.Empty;
            foreach (var entityEntry in base.ChangeTracker.Entries().Where(et => et.State != EntityState.Unchanged))
            {
                foreach (var entry in entityEntry.CurrentValues.Properties)
                {
                    var prop = entityEntry.Property(entry.Name).Metadata;
                    var value = entry.PropertyInfo?.GetValue(entityEntry.Entity);
                    var valueLength = value?.ToString()?.Length;
                    var typemapping = prop.GetTypeMapping();
                    var typeSize = ((Microsoft.EntityFrameworkCore.Storage.RelationalTypeMapping)typemapping).Size;
                    if (typeSize.HasValue && valueLength > typeSize.Value)
                    {
                        textError += $"Truncation will occur: {entityEntry.Metadata.GetTableName()}.{prop.GetColumnName()} {prop.GetColumnType()} :: {entry.Name}({valueLength}) = {value}";
                    }
                }
            }
            throw ex;
        }

        return base.SaveChanges();
    }
}