using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZitroShop.Modules.PaymentModule.Entities;

namespace ZitroShop.Modules.PaymentModule.Persistence.Context;

public class PaymentModuleDbContext(DbContextOptions<PaymentModuleDbContext> options) : DbContext(options)
{
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(PaymentModuleDbContextSchema.DefaultSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentModuleDbContext).Assembly);
    }
}
