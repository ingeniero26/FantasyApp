using FantasyApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Country>().Property(x => x.IsActive).HasDefaultValue(true);
            // Configure your entities here
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<DocumentType>().Property(x => x.IsActive).HasDefaultValue(true);
        }

        // Define DbSets for your entities
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<DocumentType> DocumentTypes { get; set; } = null!;

        // Add other DbSets as needed
    }
}