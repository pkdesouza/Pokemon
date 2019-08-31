using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        [BsonId]
        public string _id { get; set; }
        public int attack { get; set; }
        public DateTime created { get; set; }
        public int defense { get; set; }
        public string height { get; set; }
        public int hp { get; set; }
        public string name { get; set; }
        public int speed { get; set; }
        public List<string> types { get; set; }
    }
}

