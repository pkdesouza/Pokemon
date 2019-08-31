using PokemonAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPI.RepositoriesAbstractions
{
    public interface IPokemonRepositoryAbstraction
    {
        Task<IEnumerable<Pokemon>> GetAllPokemons();
    }
}
