using AcceptanceTests.Pages;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PokemonAPI.ServicesAbstractions;
using PokemonAPI.ViewModels;
using System;
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
        }

        [Test]
        public void UrlIsCorrect() => Page.CurrentUrl.Should().Be("http://localhost:7200/pokemon");

        [Test]
        public void PokemonCreated()
        {
            Page.NgNavigate();
            Page.Type(new
            {
                name = PokemonViewModel.Name,
                attack = PokemonViewModel.Attack,
                defense = PokemonViewModel.Defense,
                height = PokemonViewModel.Height,
                hp = PokemonViewModel.Hp,
                speed = PokemonViewModel.Speed,
                types = String.Join(",", PokemonViewModel.Types.ToArray())
            });
            // submit form
            Page.Submit();
            System.Threading.Thread.Sleep(1000);
            Page.ReloadPage();
            System.Threading.Thread.Sleep(2000);
            // find pokemon that was created
            Page.InputByClassName(PokemonViewModel.Name);
            System.Threading.Thread.Sleep(1000);
            // seleted pokemon
            Page.SeletedCheckBoxByName();
            System.Threading.Thread.Sleep(1000);
            // remove pokemon
            Page.ClickRemoveButtonById();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
