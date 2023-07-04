using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CodeFirst
{
	public class DataContext : DbContext
	{
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;User ID=sa;Password=Test.1234;Database=Plutodb;TrustServerCertificate=true;");
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}

