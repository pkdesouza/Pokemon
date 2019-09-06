using PokemonAPI.Models;
using PokemonAPI.RepositoriesAbstractions;
using PokemonAPI.ServicesAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly IPokemonRepositoryAbstraction _pokemonRepository;

        public PokemonService(IPokemonRepositoryAbstraction productRepository)
        {
            _pokemonRepository = productRepository;
        }
    }
}
