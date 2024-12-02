using Microsoft.EntityFrameworkCore;
using Scooterland.Shared.Models;

namespace Scooterland.Server.DataAccess
{
	public class ScooterlandDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<SalesLineItem> SalesLineItems { get; set; }
		public DbSet<Specialization> Specializations { get; set; }

		
		public string DbPath { get; }

		// The following configures EF to create a Sqlite database file in the
		// special "local" folder for your platform.
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(ConnectionHandler.GetConnectionStringEF());

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasColumnType("decimal(18,2)");  // Sets precision and scale for Price
		}
	}
}

