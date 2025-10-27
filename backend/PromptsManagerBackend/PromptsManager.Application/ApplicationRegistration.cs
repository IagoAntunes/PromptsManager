using Microsoft.Extensions.DependencyInjection;
using PromptsManager.Application.Service.Implementation;
using PromptsManager.Application.Service.Interface;
namespace PromptsManager.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services
        )
        {
            services.AddAutoMapper(cfg =>
            {
                
            });
            services.AddScoped<IAuthService, AuthServiceImpl>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
