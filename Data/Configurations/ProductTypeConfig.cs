using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Round2Api.Models;

namespace Round2Api.Data.Configurations;

public class ProductTypeConfig:IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(p=>p.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}