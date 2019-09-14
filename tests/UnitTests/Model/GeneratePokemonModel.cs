using Bogus;
using PokemonAPI.Models;
using PokemonAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace NUnitTestPokemon.Model
{
    public class GeneratePokemonModel
    {
        public PokemonViewModel PokemonViewModelValid
        {
            get => new Faker<PokemonViewModel>()
                .StrictMode(true)
                .RuleFor(o => o.Attack, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Defense, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Height, f => f.Random.Number(1, 999).ToString())
                .RuleFor(o => o.Hp, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Name, f => f.Person.FirstName)
                .RuleFor(o => o.Speed, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Types, f => new List<string> { "normal" })
                .Generate();
        }
        public IList<PokemonViewModel> PokemonViewModelValidList
        {
            get
            {
                var pokemons = new List<PokemonViewModel>();
                var count = new Random().Next(2, 10);

                for (int i = 0; i < count; i++)
                    pokemons.Add(PokemonViewModelValid);
                return pokemons;
            }
        }

        public PokemonViewModel PokemonViewModelInvalid
        {
            get => new Faker<PokemonViewModel>()
                .StrictMode(true)
                .RuleFor(o => o.Attack, f => f.Random.Number(950, 1500))
                .RuleFor(o => o.Defense, f => f.Random.Number(950, 1500))
                .RuleFor(o => o.Height, f => f.Random.Number(1, 1500).ToString())
                .RuleFor(o => o.Hp, f => f.Random.Number(950, 1500))
                .RuleFor(o => o.Name, f => f.Person.FirstName)
                .RuleFor(o => o.Speed, f => f.Random.Number(950, 1500))
                .RuleFor(o => o.Types, f => new List<string> { "normal" })
                .Generate();
        }
        public IList<PokemonViewModel> PokemonViewModelInvalidList
        {
            get
            {
                var pokemons = new List<PokemonViewModel>();
                var count = new Random().Next(2, 10);

                for (int i = 0; i < count; i++)
                    pokemons.Add(PokemonViewModelInvalid);
                return pokemons;
            }
        }
        public PokemonUpdateViewModel PokemonUpdateViewModel
        {
            get => new Faker<PokemonUpdateViewModel>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => f.Random.Guid())
                .RuleFor(o => o.Attack, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Defense, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Height, f => f.Random.Number(1, 999).ToString())
                .RuleFor(o => o.Hp, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Name, f => f.Person.FirstName)
                .RuleFor(o => o.Speed, f => f.Random.Number(1, 999))
                .RuleFor(o => o.Types, f => new List<string> { "normal" })
                .Generate();
        }
        public IList<PokemonUpdateViewModel> PokemonUpdateViewModelList
        {
            get
            {
                var pokemons = new List<PokemonUpdateViewModel>();
                var count = new Random().Next(2, 10);

                for (int i = 0; i < count; i++)
                    pokemons.Add(PokemonUpdateViewModel);
                return pokemons;
            }
        }

        public Pokemon PokemonModel
        {
            get => new Pokemon(PokemonViewModelValid);
        }
        public IList<Pokemon> PokemonListModel
        {
            get
            {
                var pokemons = new List<Pokemon>();
                var count = new Random().Next(2, 10);

                for (int i = 0; i < count; i++)
                    pokemons.Add(new Pokemon(PokemonViewModelValid));
                return pokemons;
            }
        }
    }
}

