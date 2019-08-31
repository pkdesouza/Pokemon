using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonAPI.Context;
using PokemonAPI.Models;
using PokemonAPI.Models.MongoDB;
using PokemonAPI.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPI.Repositories
{
    public class PokemonRepository : IPokemonRepositoryAbstraction
    {
        private readonly MongoContext context = null;

        public PokemonRepository(IOptions<Settings> settings)
        {
            context = new MongoContext(settings);
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            return await context.Pokemon.Find(_ => true).ToListAsync();
        }
    }
}
