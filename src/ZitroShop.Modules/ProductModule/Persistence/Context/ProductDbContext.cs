using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZitroShop.Modules.ProductModule.Entities;

namespace ZitroShop.Modules.ProductModule.Persistence.Context;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public DbSet<Product> Wallets => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(ProductDbContextSchema.DefaultSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
