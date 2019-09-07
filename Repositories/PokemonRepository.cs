using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonAPI.Context;
using PokemonAPI.Context.Abstraction;
using PokemonAPI.Models;
using PokemonAPI.Models.MongoDB;
using PokemonAPI.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPI.Repositories
{
    public class PokemonRepository : BaseRepository<Pokemon>, IPokemonRepositoryAbstraction
    {        
        public PokemonRepository(IMongoContext context) : base(context)
        {
            
        }
    }
}
