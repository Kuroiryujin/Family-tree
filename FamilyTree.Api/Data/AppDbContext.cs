using FamilyTree.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Api.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor accepting options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        // Add DbSet<T> here for each entity
        public DbSet<Person> People { get; set; }

        // Optional: Configure model if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}