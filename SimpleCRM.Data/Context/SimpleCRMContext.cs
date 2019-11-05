using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<DailyTaskMessage> DailyTaskMessages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimpleCRM.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<DailyTask>().ToTable("DailyTask");
            modelBuilder.Entity<Role>().ToTable("Role");
        }

    }
}
