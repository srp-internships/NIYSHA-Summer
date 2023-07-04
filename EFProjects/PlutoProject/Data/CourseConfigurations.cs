using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Data
{
	public class CourseConfigurations : IEntityTypeConfiguration<Course>
	{
		

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(255);

          
               builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

               builder.HasMany(c => c.Tags)
                .WithMany(t => t.Courses);

         
              builder.HasOne(u => u.Cover)
               .WithOne(p => p.Course)
               .HasForeignKey<Cover>(p => p.Id);

         
        }
    }
}

