using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonAPI.Context;
using PokemonAPI.Context.Abstraction;
using PokemonAPI.Models.MongoDB;
using PokemonAPI.RepositoriesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PokemonAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<T> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<T>(typeof(T).Name);
        }

        public virtual void Add(T obj)
        {
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IList<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var all = DbSet.AsQueryable().Where(predicate);
            return all.ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public Task SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

}