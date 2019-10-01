using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace PokemonAPI.Context.Abstraction
{
    public interface IMongoContext: IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        Task<bool> Commit();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
