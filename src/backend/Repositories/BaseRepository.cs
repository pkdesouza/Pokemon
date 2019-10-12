using MongoDB.Driver;
using PokemonAPI.Context.Abstraction;
using PokemonAPI.RepositoriesAbstractions;
using ServiceStack;
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
            DbSet = _context.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.AddCommand(async () => await DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
            await _context.Commit();
        }

        public async Task DeleteAsync(IList<Guid> ids)
        {
            _context.AddCommand(async () => await DbSet.DeleteManyAsync(Builders<T>.Filter.In("_id", ids)));
            await _context.Commit();
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var all = await GetAllAsync();
            return all.AsQueryable().Where(predicate).ToList();
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

        public async Task SaveAsync(T entity)
        {
            _context.AddCommand(async () => await DbSet.InsertOneAsync(entity));
            await _context.Commit();
        }

        public async Task SaveAsync(IList<T> entities)
        {
            _context.AddCommand(async () => await DbSet.InsertManyAsync(entities));
            await _context.Commit();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.AddCommand(async () => await DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.GetId()), entity, new UpdateOptions { IsUpsert = true }));
            await _context.Commit();
        }

        public async Task UpdateAsync(IList<T> entities)
        {
            foreach (var entity in entities)
                _context.AddCommand(async () => await DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.GetId()), entity, new UpdateOptions { IsUpsert = true }));

            await _context.Commit();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }

}