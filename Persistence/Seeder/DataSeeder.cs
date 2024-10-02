using Microsoft.EntityFrameworkCore;
using DatabaseSync.Persistence.Entities;

namespace DatabaseSync.Persistence.Seeder
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedCustomers(modelBuilder);
            SeedLocations(modelBuilder);
        }

        public static void SeedCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, Name = "John Doe", Email = "john@example.com", Phone = "1234567890" },
                new Customer { CustomerID = 2, Name = "Jane Smith", Email = "jane@example.com", Phone = "0987654321" },
                new Customer { CustomerID = 3, Name = "Alice Johnson", Email = "alice@example.com", Phone = "1122334455" },
                new Customer { CustomerID = 4, Name = "Bob Brown", Email = "bob@example.com", Phone = "2233445566" },
                new Customer { CustomerID = 5, Name = "Charlie White", Email = "charlie@example.com", Phone = "3344556677" },
                new Customer { CustomerID = 6, Name = "David Green", Email = "david@example.com", Phone = "4455667788" },
                new Customer { CustomerID = 7, Name = "Eve Blue", Email = "eve@example.com", Phone = "5566778899" },
                new Customer { CustomerID = 8, Name = "Frank Black", Email = "frank@example.com", Phone = "6677889900" },
                new Customer { CustomerID = 9, Name = "Grace Silver", Email = "grace@example.com", Phone = "7788990011" },
                new Customer { CustomerID = 10, Name = "Hank Gold", Email = "hank@example.com", Phone = "8899001122" },
                new Customer { CustomerID = 11, Name = "Ivy Red", Email = "ivy@example.com", Phone = "9900112233" },
                new Customer { CustomerID = 12, Name = "Jake Violet", Email = "jake@example.com", Phone = "1010101010" },
                new Customer { CustomerID = 13, Name = "Liam Orange", Email = "liam@example.com", Phone = "1111111111" },
                new Customer { CustomerID = 14, Name = "Mia Cyan", Email = "mia@example.com", Phone = "1212121212" },
                new Customer { CustomerID = 15, Name = "Noah Brown", Email = "noah@example.com", Phone = "1313131313" },
                new Customer { CustomerID = 16, Name = "Olivia Pink", Email = "olivia@example.com", Phone = "1414141414" },
                new Customer { CustomerID = 17, Name = "Peter Gray", Email = "peter@example.com", Phone = "1515151515" },
                new Customer { CustomerID = 18, Name = "Quinn Magenta", Email = "quinn@example.com", Phone = "1616161616" },
                new Customer { CustomerID = 19, Name = "Ryan Lime", Email = "ryan@example.com", Phone = "1717171717" },
                new Customer { CustomerID = 20, Name = "Sophia Peach", Email = "sophia@example.com", Phone = "1818181818" }
            );
        }

        public static void SeedLocations(ModelBuilder modelBuilder)
        {
            // Seed multiple locations for each customer
            var locations = new List<Location>();

            for (int i = 1; i <= 20; i++)
            {
                // Each customer will have 3 locations with different addresses
                locations.Add(new Location { LocationID = (i - 1) * 3 + 1, CustomerID = i, Address = $"Address {i} - 1" });
                locations.Add(new Location { LocationID = (i - 1) * 3 + 2, CustomerID = i, Address = $"Address {i} - 2" });
                locations.Add(new Location { LocationID = (i - 1) * 3 + 3, CustomerID = i, Address = $"Address {i} - 3" });
            }

            modelBuilder.Entity<Location>().HasData(locations);
        }
    }
}
