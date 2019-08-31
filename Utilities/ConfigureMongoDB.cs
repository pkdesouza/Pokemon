using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonAPI.Models.MongoDB;

namespace PokemonAPI.Utilities
{
    public static class ConfigureMongoDB
    {
        public static IServiceCollection ConfigureMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = configuration.GetSection("MongoConnection:Database").Value;
            });

            return services;
        }
    }
}
