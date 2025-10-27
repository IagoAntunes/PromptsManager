using Microsoft.EntityFrameworkCore;
using PromptsManager.Domain.Entities;

namespace PromptsManager.Infrastructure.Data
{
    public class PromptsManagerDbContext : DbContext
    {

        public PromptsManagerDbContext(DbContextOptions<PromptsManagerDbContext> dbOptions)
            : base(dbOptions)
        {
            
        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<PromptEntity> Prompts => Set<PromptEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.EmailNormalized)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Email)
                .HasMaxLength(256);

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.EmailNormalized)
                .HasMaxLength(256);




        }

    }
}
