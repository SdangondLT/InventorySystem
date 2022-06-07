using InventorySystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<Movement> Movement { get; set; }

        private readonly string _connectionString = string.Empty;

        public SqlServerContext()
        {
            _connectionString = @"Data Source = DESKTOP-IF9J0OU\SQLEXPRESS; Initial Catalog = InventorySystem; Integrated Security = true";
        }
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey(c => new { c.IdItem });
            modelBuilder.Entity<Item>().Property(c => c.IdItem).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        
            modelBuilder.Entity<Movement>().HasKey(c => new { c.IdMovement });
            modelBuilder.Entity<Movement>().Property(c => c.IdMovement).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
