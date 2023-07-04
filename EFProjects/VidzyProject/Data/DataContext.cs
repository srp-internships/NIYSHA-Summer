using System;
using System.Reflection;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace Vidzy
{
	public class DataContext:DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;User ID=sa;Password=Test.1234;Database=VidzyProject;TrustServerCertificate=true;");
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

