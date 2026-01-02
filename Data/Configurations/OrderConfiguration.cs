using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Round2Api.Models.Order;

namespace Round2Api.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Status)
                .HasConversion(OS => OS.ToString(), OS => (OrderStatus)Enum.Parse(typeof(OrderStatus), OS));


            builder.Property(o => o.SubTotal)
                .HasColumnType("decimal(18,2)");


            builder.OwnsOne(o => o.ShippingAddress, a => a.WithOwner());

            builder.HasOne(o => o.DeliveryMethod)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
