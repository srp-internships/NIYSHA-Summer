using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidzy;

namespace VidzyProject.Data
{
	public class TagConfigurations: IEntityTypeConfiguration<Genre>
    {
       

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(c => c.Name)
               .IsRequired()
            .HasMaxLength(255);
        }
    }
}

