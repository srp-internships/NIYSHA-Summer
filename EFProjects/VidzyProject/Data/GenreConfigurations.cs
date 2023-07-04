using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vidzy.Data
{
	public class GenreConfigurations : IEntityTypeConfiguration<Genre>
    {
		
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(c => c.Name)
               .IsRequired()
            .HasMaxLength(255);

        }
    }
}

