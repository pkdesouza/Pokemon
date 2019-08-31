using CommandAPI.Services;
using CommandAPI.ServicesAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace WebLayer.Utilities
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection RegisterDependencyServices(
            this IServiceCollection services)
        {
            // Adicionar futuros services aqui diego
            services.AddTransient<IPokemonService, PokemonService>();

            return services;
        }
    }
}