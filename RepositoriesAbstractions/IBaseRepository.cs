using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PokemonAPI.RepositoriesAbstractions
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task SaveAsync(T entity);
        Task SaveAsync(IList<T> entities);
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(T entity);
        Task UpdateAsync(IList<T> entities);
        Task DeleteAsync(string id);
        Task DeleteAsync(IList<string> ids);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
