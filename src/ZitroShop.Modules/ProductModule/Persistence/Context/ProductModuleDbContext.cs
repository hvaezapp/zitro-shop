using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZitroShop.Modules.ProductModule;
using ZitroShop.Modules.ProductModule.Entities;

namespace ZitroShop.Modules.ProductModule.Persistence.Context;

public class ProductModuleDbContext(DbContextOptions<ProductModuleDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(ProductModuleDbContextSchema.DefaultSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductModuleDbContext).Assembly);

    }
}
