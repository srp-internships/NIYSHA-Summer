using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseProject.Data
{
	public class StoreConfigurations : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(c => c.Name)
             .IsRequired()
            .HasMaxLength(255);

            builder.HasMany(e => e.Sales)
              .WithOne(e => e.Store)
              .HasForeignKey(e => e.StoreId)
              .HasPrincipalKey(e => e.Id);
        }
    
    }
}

