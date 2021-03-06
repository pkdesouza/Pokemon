using PokemonAPI.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;
using PokemonAPI.ServicesAbstractions;
using PokemonAPI.Services;
using PokemonAPI.Context.Abstraction;
using PokemonAPI.Context;
using PokemonAPI.Models.MongoDB;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PokemonAPI.Models;
using PokemonAPI.ViewModels;
using XUnitTestPokemon.Model;

namespace XIntegrationTestPokemon
{
    public class XTestIntegrationPokemon
    {
        public readonly IPokemonService PokemonService;

        public readonly PokemonController PokemonController;
        public GeneratePokemonModel GenerateModel { get => new GeneratePokemonModel(); }

        public XTestIntegrationPokemon()
        {
            Settings appSettings = new Settings()
            {
                ConnectionString = "mongodb://localhost:27017",
                Database = "pokemonDB"
            };
            IOptions<Settings> options = Options.Create(appSettings);
            IMongoContext context = new MongoContext(options);
            PokemonService = new PokemonService(context);
            PokemonController = new PokemonController(PokemonService);
        }

        [Fact]
        public async Task TestIntegrationPokemon()
        {
            // Create
            var pokemon = GenerateModel.PokemonViewModelValid;
            var pokemonCreate = await CreateAsync(pokemon);
            var pokemonGet = await GetByIdAsync(pokemonCreate.Id);
            Assert.NotNull(pokemonGet);

            // Update
            pokemon.Name = $"{pokemon.Name} teste Update";
            await UpdateAsync(pokemonGet.Id, pokemon);
            pokemonGet = await GetByIdAsync(pokemonCreate.Id);
            Assert.Equal(pokemonGet.Name, pokemon.Name);
            
            // Delete
            await DeleteAsync(pokemonGet.Id);
            await Assert.ThrowsAsync<InvalidCastException>(async () => await GetByIdAsync(pokemonGet.Id));
        }
   
        internal async Task<Pokemon> GetByIdAsync(Guid guid)
        {
            var result = await PokemonController.GetByIdAsync(guid);
            var pokemonResult = ((OkObjectResult)result).Value;
            return (Pokemon)pokemonResult;
        }

        internal async Task<Pokemon> CreateAsync(PokemonViewModel pokemonViewModel)
        {
            var result = await PokemonController.CreateAsync(pokemonViewModel);
            Assert.True(((OkObjectResult)result).StatusCode.Equals(StatusCodes.Status200OK));
            var pokemonResult = ((OkObjectResult)result).Value;
            return (Pokemon)pokemonResult;
        }

        internal async Task UpdateAsync(Guid id, PokemonViewModel pokemonViewModel)
        {
            var result = await PokemonController.UpdateAsync(id, pokemonViewModel);
            Assert.True(((OkResult)result).StatusCode.Equals(StatusCodes.Status200OK));
        }

        internal async Task DeleteAsync(Guid id)
        {
            var result = await PokemonController.DeleteAsync(id);
            Assert.True(((OkResult)result).StatusCode.Equals(StatusCodes.Status200OK));
        }
    }
}
