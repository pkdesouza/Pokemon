using NUnitTestPokemon.Model;
using Xunit;

namespace NUnitTestPokemon.ViewModelTest
{
    public class PokemonViewModelTest
    {
        public GeneratePokemonModel GenerateModel { get => new GeneratePokemonModel(); }

        [Fact]
        public void Valid() {
            var ex = Record.Exception(() => GenerateModel.PokemonViewModelValid.Valid());
            Assert.Null(ex);
        }

        [Fact]
        public void Invalid()
        {
            var ex = Record.Exception(() => GenerateModel.PokemonViewModelInvalid.Valid());
            Assert.NotNull(ex);
        }
    }
}
