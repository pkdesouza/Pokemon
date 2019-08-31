using PokemonAPI.Models;
using PokemonAPI.RepositoriesAbstractions;
using PokemonAPI.ServicesAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly IPokemonRepositoryAbstraction PokemonRepository = null;

        public PokemonService(IPokemonRepositoryAbstraction pokemonRepositoryAbstraction)
        {
            PokemonRepository = pokemonRepositoryAbstraction;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            return await PokemonRepository.GetAllPokemons();
        }
    }
}
