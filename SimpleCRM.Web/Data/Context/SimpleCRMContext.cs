using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SimpleCRM.Data.Models;


namespace SimpleCRM.Data.Context
{
    public class SimpleCRMContext : DbContext
    {
        public SimpleCRMContext(DbContextOptions<SimpleCRMContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

		
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("Data Source=SimpleCRM.db");
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
