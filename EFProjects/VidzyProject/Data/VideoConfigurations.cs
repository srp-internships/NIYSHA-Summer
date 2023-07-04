using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vidzy.Data
{
    public class VideoConfigurations : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
           
            builder.Property(c => c.Name)
               .IsRequired()
            .HasMaxLength(255);

          

            builder.HasMany(v => v.Tags)
            .WithMany(t => t.Videos);

            builder.HasOne(e=>e.Genre)
      .WithMany(s => s.Videos)
      .IsRequired();

        }
    }
}

