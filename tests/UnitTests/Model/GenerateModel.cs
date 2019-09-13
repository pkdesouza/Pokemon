using Bogus;
using PokemonAPI.ViewModels;
using System.Collections.Generic;

namespace NUnitTestPokemon.Model
{
    public class GenerateModel
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
    }
}

