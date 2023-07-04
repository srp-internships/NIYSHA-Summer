using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WarehouseProject.Data
{
	public class DataContext:DbContext
	{
		
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;User ID=sa;Password=Test.1234;Database=Warehousedb;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Receipt> Receipts{ get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<Store> Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

