using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseProject.Data
{
    public class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
             .HasMaxLength(255);

            builder.HasMany(e => e.Receipts)
      .WithOne(e => e.Provider)
      .HasForeignKey(e => e.ProviderId)
      .HasPrincipalKey(e => e.Id);
        }
    }
}

