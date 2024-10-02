using DatabaseSync.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSync.Persistence.Context
{
    public class LocalDbContext : DbContext
    {
        private string DbPath { get; }
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
            // This code sets the database file path to the user's Local Application Data folder.
            // Example: C:\Users\<username>\AppData\Local\db_sync.db
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "db_sync.db");
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SyncLog> SyncLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
