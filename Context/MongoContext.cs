using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonAPI.Models;
using PokemonAPI.Models.MongoDB;

namespace PokemonAPI.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase database = null;

        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Pokemon> Pokemon
        {
            get => database.GetCollection<Pokemon>("pokemon");
        }
    }
}
