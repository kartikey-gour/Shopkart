using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity => {
                entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

                entity.HasIndex(u => u.Email)
                .IsUnique();
            });
        }
    }
}