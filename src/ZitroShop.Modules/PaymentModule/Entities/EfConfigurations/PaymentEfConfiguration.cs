using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZitroShop.Modules.PaymentModule.Persistence.Context;
using ZitroShop.Modules.ProductModule.Persistence.Context;

namespace ZitroShop.Modules.PaymentModule.Entities.EfConfigurations;

public class PaymentEfConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(PaymentModuleDbContextSchema.Payment.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
               .IsRequired(true);

        builder.Property(x => x.Amount)
                  .IsRequired(true)
                  .HasColumnType(PaymentModuleDbContextSchema.DefaultDecimalColumnType);

    }
}
