using AcceptanceTests.Pages;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PokemonAPI.ServicesAbstractions;
using PokemonAPI.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using XUnitTestPokemon.Model;

namespace AcceptanceTests.Tests
{
    public class ProductCreateTest : BaseAcceptanceTest<PokemonCreatePage>
    {
        private IPokemonService service;

        private PokemonViewModel PokemonViewModel;

        [OneTimeSetUp]
        public void CreatePokemon()
        {
            service = serviceProvider.GetService<IPokemonService>();
            PokemonViewModel = new GeneratePokemonModel().PokemonViewModelValid;
            Page.NgNavigate();
            Page.Type(PokemonViewModel);
            Page.Submit();
            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void UrlIsCorrect() => Page.CurrentUrl.Should().Be("http://localhost:7200/pokemon");

        [Test]
        public async Task PokemonCreated()
        {
            var pokemon = await service.FindAsync(x => x.Name == PokemonViewModel.Name);
            pokemon.Count().Should().Be(1);
        }
    }
}
