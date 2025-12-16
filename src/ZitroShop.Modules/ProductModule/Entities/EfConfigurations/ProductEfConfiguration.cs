using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZitroShop.Modules.ProductModule.Persistence.Context;

namespace ZitroShop.Modules.ProductModule.Entities.EfConfigurations;

public class ProductEfConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(ProductModuleDbContextSchema.Product.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(50);

        builder.Property(x => x.Description)
                    .IsRequired(true)
                    .HasMaxLength(300);

        builder.Property(x => x.Price)
                  .IsRequired(true)
                  .HasColumnType(ProductModuleDbContextSchema.DefaultDecimalColumnType);

    }
}
