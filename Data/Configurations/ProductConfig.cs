using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Round2Api.Models;

namespace Round2Api.Data.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p=>p.ProductBrand)
            .WithMany()
            .HasForeignKey(p=>p.ProductBrandId);
        builder.HasOne(p=>p.ProductType)
            .WithMany()
            .HasForeignKey(p=>p.ProductTypeId);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(p => p.ImageUrl)
            .IsRequired();
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
    }
}