using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        [BsonId]
        public string Id { get; set; }
        public int Attack { get; set; }
        public DateTime Created { get; set; }
        public int Defense { get; set; }
        public string Height { get; set; }
        public int Hp { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public List<string> Types { get; set; }
    }
}

