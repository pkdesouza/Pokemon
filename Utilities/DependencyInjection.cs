using PokemonAPI.Services;
using PokemonAPI.ServicesAbstractions;
using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Repositories;
using PokemonAPI.RepositoriesAbstractions;

namespace PokemonAPI.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IPokemonService, PokemonService>();
            #endregion

            #region Repositories
            services.AddTransient<IPokemonRepositoryAbstraction, PokemonRepository>();
            #endregion

            return services;
        }
    }
}