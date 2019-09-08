using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PokemonAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public Pokemon(PokemonViewModel pokemon)
        {
            Id = Guid.NewGuid(); 
            Attack = pokemon.Attack;
            Defense = pokemon.Defense;
            Height = pokemon.Height;
            Hp = pokemon.Hp;
            Name = pokemon.Name;
            Speed = pokemon.Speed;
            Types = pokemon.Types;
            Created = DateTime.Now;
        }
        public Pokemon(PokemonViewModel pokemon, Guid id) : this(pokemon){
            Id = id;
        }
        [BsonId]
        public Guid Id { get; set; }
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

