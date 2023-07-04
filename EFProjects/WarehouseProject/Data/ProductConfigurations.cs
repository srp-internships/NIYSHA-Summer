using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseProject.Data
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
             .HasMaxLength(255);

            builder.HasMany(e => e.Sales)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.ProductId)
            .HasPrincipalKey(e => e.Id);

            builder.HasMany(e => e.Receipts)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.ProductId)
            .HasPrincipalKey(e => e.Id);
        }
    }
}

