# 001_DataAnotation_FluentAPI
# Data Annotations and Fluent API in Entity Framework Core

In this example, we demonstrate how to use Data Annotations and Fluent API to configure the entity relationships and model in Entity Framework Core using C#.

## AppContext Class

The `AppContext` class is derived from `DbContext` and represents the database context. It includes configurations for entity sets and database connections.

```csharp
using Microsoft.EntityFrameworkCore;

namespace _001_DataAnotation_FluentAPI
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            Database.EnsureDeleted();
        }

        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=TestDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and model using Fluent API
            modelBuilder.Entity<Planshet>();
        }
    }
}
