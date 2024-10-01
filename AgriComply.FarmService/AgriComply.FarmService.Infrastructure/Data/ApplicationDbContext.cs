using Microsoft.EntityFrameworkCore;
using AgriComply.FarmerService.Domain.Aggregates;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AgriComply.FarmerService.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Farmers
        public DbSet<Farmer> Farmers { get; set; }

        // You can add more DbSets for other aggregates here
        // public DbSet<Property> Properties { get; set; }
        // public DbSet<Compliance> Compliances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity properties, relationships, etc.
            modelBuilder.Entity<Farmer>()
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Additional configurations can be added for other entities
        }
    }
}
