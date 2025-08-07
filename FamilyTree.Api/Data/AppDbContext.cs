using FamilyTree.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PersonEntity> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many relationship between Parents and Children
            modelBuilder.Entity<PersonEntity>()
                .HasMany(p => p.Parents)
                .WithMany(p => p.Children)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonRelationship", // Junction table name
                    j => j.HasOne<PersonEntity>().WithMany().HasForeignKey("ParentId"),
                    j => j.HasOne<PersonEntity>().WithMany().HasForeignKey("ChildId")
                );
        }
    }
}