using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Entities;

namespace Orders.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entityBuilder)
    {
        entityBuilder.ToTable("Orders");

        entityBuilder.HasKey(e => e.Id);

        entityBuilder.Property(e => e.Id)
            .IsRequired();

        entityBuilder
            .OwnsOne(e => e.TotalPrice);

        entityBuilder.OwnsOne(e => e.TotalPrice, cb =>
        {
            cb.OwnsOne(p => p.Currency);
            cb.Property(p => p.Amount).HasColumnName("TotalPrice_Amount");
        });

        entityBuilder.OwnsOne(e => e.BillingAddress);

        entityBuilder.OwnsOne(e => e.PaymentDetails);

        entityBuilder.Ignore(e => e.Events);
    }
}