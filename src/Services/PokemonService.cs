using PokemonAPI.Context.Abstraction;
using PokemonAPI.Models;
using PokemonAPI.ServicesAbstractions;

namespace PokemonAPI.Services
{
    public class PokemonService : BaseService<Pokemon>, IPokemonService
    {
        public PokemonService(IMongoContext context) : base(context)
        {

        }
    }
}
