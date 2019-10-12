using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using PokemonAPI.Context.Abstraction;
using PokemonAPI.Models.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Context
{
    public class MongoContext : IMongoContext, IDisposable
    {
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
        private List<Func<Task>> _commands;
        public IClientSessionHandle Session { get; set; }

        public MongoContext(IOptions<Settings> settings)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;            
            _commands = new List<Func<Task>>();

            RegisterConventions();

            MongoClient = new MongoClient(settings.Value.ConnectionString);
            Database = MongoClient.GetDatabase(settings.Value.Database);
        }
        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("ConventionPack", pack, t => true);
        }

        public async Task<int> SaveChanges()
        {
            var count = _commands.Count;
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();
                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);
                await Session.CommitTransactionAsync();
                _commands = new List<Func<Task>>();
            }
            return count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public async Task<bool> Commit() => await SaveChanges() > 0;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}
