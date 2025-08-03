using FamilyTree.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Api.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor accepting options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PersonEntity> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonEntity>(entity =>
            {
                entity.HasOne(p => p.Mother)
                    .WithMany()
                    .HasForeignKey(p => p.MotherId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Father)
                    .WithMany()
                    .HasForeignKey(p => p.FatherId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}