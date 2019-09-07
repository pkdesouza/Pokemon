using PokemonAPI.Context.Abstraction;
using PokemonAPI.Repositories;
using PokemonAPI.RepositoriesAbstractions;

namespace PokemonAPI.Services
{
    public class BaseService<T> : BaseRepository<T>, IBaseRepository<T> where T : class
    {
        public BaseService(IMongoContext context) : base(context)
        {

        }
        
    }
}
