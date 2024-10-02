using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.Seeder;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSync.Persistence.Context
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=db_sync;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DataSeeder.Seed(modelBuilder);

            // Configure Customer entity
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerID);
            });

            // Configure Location entity
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationID);

                // Define the one-to-many relationship between Customer and Location
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Locations)
                    .HasForeignKey(e => e.CustomerID)
                    .OnDelete(DeleteBehavior.Cascade);  // Cascade delete locations when a customer is deleted
            });
        }
    }
}
