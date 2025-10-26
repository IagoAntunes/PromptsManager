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



    }
}
