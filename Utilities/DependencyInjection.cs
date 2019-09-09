using PokemonAPI.Services;
using PokemonAPI.ServicesAbstractions;
using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Repositories;
using PokemonAPI.RepositoriesAbstractions;
using PokemonAPI.Context;
using PokemonAPI.Context.Abstraction;

namespace PokemonAPI.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services)
        {

            #region context
            services.AddScoped<IMongoContext, MongoContext>();
            #endregion

            #region Services
            services.AddScoped<IPokemonService, PokemonService>();
            #endregion

            #region Repositories
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            #endregion

            return services;
        }
    }
}