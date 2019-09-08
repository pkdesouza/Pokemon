using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace PokemonAPI.Models.MongoDB
{
    public class Map
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Pokemon>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.SetIdMember(map.GetMemberMap(x => x.Id));
                map.MapMember(x => x.Name).SetIsRequired(true);
                map.MapMember(x => x.Speed);
                map.MapMember(x => x.Height);
                map.MapMember(x => x.Hp);
                map.MapMember(x => x.Types);
                map.MapMember(x => x.Attack);
                map.MapMember(x => x.Created).ApplyDefaultValue(DateTime.Now);
                map.MapMember(x => x.Defense);
            });
        }
    }
}
