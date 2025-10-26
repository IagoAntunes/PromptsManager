using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromptsManager.Domain.Repository;
using PromptsManager.Infrastructure.Data;

namespace PromptsManager.Infrastructure
{
    public static class InfrastructureRegistration
    {

        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
        IConfiguration configuration
)
        {
            services.AddDbContext<PromptsManagerDbContext>(
               options => options.UseSqlServer(
                   configuration.GetConnectionString("PromptsManagerConnectionString")
               )
            );
            services.AddScoped<IAuthRepository,AuthRepositoryImpl>();
            return services;
        }

    }
}
