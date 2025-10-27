using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromptsManager.Application.Mapping;
using PromptsManager.Domain.Entities;
using PromptsManager.Domain.Repository;
using PromptsManager.Infrastructure.Data;
using PromptsManager.Infrastructure.Mapping;

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
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DtoToEntityMapper>();
            });
            services.AddScoped<IAuthRepository,AuthRepositoryImpl>();
            services.AddScoped<IPromptRepository,PromptRepositoryImpl>();
            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
            return services;
        }

    }
}
