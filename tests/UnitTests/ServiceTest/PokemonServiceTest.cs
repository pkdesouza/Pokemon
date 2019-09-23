using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnitTestPokemon.Model;
using PokemonAPI.Controllers;
using PokemonAPI.Models;
using PokemonAPI.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestPokemon.ServiceTest
{
    public class PokemonServiceTest
    {
        public GeneratePokemonModel GenerateModel { get => new GeneratePokemonModel(); }

        [Fact]
        public async Task GetAllAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            var expectedPokemon = GenerateModel.PokemonListModel;

            pokemonRepositoryMock.Setup(pr => pr.GetAllAsync()).ReturnsAsync(expectedPokemon);

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.GetAllAsync();

            Assert.True(((OkObjectResult)pokemonRetrieved).Value.Equals(expectedPokemon));
        }

        [Fact]
        public async Task GetByIdAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            var expectedPokemon = GenerateModel.PokemonModel;

            pokemonRepositoryMock.Setup(pr => pr.GetByIdAsync(expectedPokemon.Id)).ReturnsAsync(expectedPokemon);

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.GetByIdAsync(expectedPokemon.Id);

            Assert.True(((OkObjectResult)pokemonRetrieved).Value.Equals(expectedPokemon));
        }

        [Fact]
        public async Task CreateAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            var expectedPokemonParam = GenerateModel.PokemonViewModelValid;
            var expectedPokemon = new Pokemon(expectedPokemonParam);

            pokemonRepositoryMock.Setup(pr => pr.SaveAsync(expectedPokemon));

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.CreateAsync(expectedPokemonParam);

            Assert.True(((CreatedAtActionResult)pokemonRetrieved).StatusCode.Equals(StatusCodes.Status201Created));
        }

        [Fact]
        public async Task CreateManyAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            var expectedPokemonList = new List<Pokemon>();
            var expectedPokemonParamList = GenerateModel.PokemonViewModelValidList;

            foreach (var pokemonViewModel in expectedPokemonParamList)
                expectedPokemonList.Add(new Pokemon(pokemonViewModel));

            pokemonRepositoryMock.Setup(pr => pr.SaveAsync(expectedPokemonList));

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.CreateManyAsync(expectedPokemonParamList);

            Assert.True(((CreatedAtActionResult)pokemonRetrieved).StatusCode.Equals(StatusCodes.Status201Created));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            Guid guid = Guid.NewGuid();

            pokemonRepositoryMock.Setup(pr => pr.DeleteAsync(guid));

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.DeleteAsync(guid);

            Assert.True(((OkResult)pokemonRetrieved).StatusCode.Equals(StatusCodes.Status200OK));
        }
        [Fact]
        public async Task DeleteManyAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            List<Guid> guids = new List<Guid>();
            var count = new Random().Next(2, 10);

            for (int i = 0; i < count; i++)
                guids.Add(Guid.NewGuid());

            pokemonRepositoryMock.Setup(pr => pr.DeleteAsync(guids));

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.DeleteManyAsync(guids);

            Assert.True(((OkResult)pokemonRetrieved).StatusCode.Equals(StatusCodes.Status200OK));
        }
        [Fact]
        public async Task UpdateAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            var expectedPokemonParam = GenerateModel.PokemonViewModelValid;
            var expectedPokemon = new Pokemon(expectedPokemonParam);

            pokemonRepositoryMock.Setup(pr => pr.UpdateAsync(expectedPokemon));

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.UpdateAsync(expectedPokemon.Id, expectedPokemonParam);

            Assert.True(((OkResult)pokemonRetrieved).StatusCode.Equals(StatusCodes.Status200OK));
        }

        [Fact]
        public async Task UpdateManyAsync()
        {
            var pokemonRepositoryMock = new Mock<IPokemonService>();
            var pokemonUpdateViewModelList = GenerateModel.PokemonUpdateViewModelList;
            var pokemonList = new List<Pokemon>();

            foreach (var pokemonUpdateViewModel in pokemonUpdateViewModelList)
                pokemonList.Add(new Pokemon(pokemonUpdateViewModel, pokemonUpdateViewModel.Id));
            
            pokemonRepositoryMock.Setup(pr => pr.UpdateAsync(pokemonList));

            var pokemonController = new PokemonController(pokemonRepositoryMock.Object);
            var pokemonRetrieved = await pokemonController.UpdateManyAsync(pokemonUpdateViewModelList);

            Assert.True(((OkResult)pokemonRetrieved).StatusCode.Equals(StatusCodes.Status200OK));
        }
    }
}
