using PokemonAPI.RepositoriesAbstractions;

namespace PokemonAPI.Services.Abstractions
{
    public interface IBaseService<T> : IBaseRepository<T> where T : class
    {

    }
}
