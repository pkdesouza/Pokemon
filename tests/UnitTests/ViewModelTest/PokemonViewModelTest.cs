using NUnitTestPokemon.Model;
using Xunit;

namespace NUnitTestPokemon.ViewModelTest
{
    public class PokemonViewModelTest
    {
        public GenerateModel GenerateModel { get => new GenerateModel(); }

        [Fact]
        public void Valid() {
            void valid() => GenerateModel.PokemonViewModelValid.Valid();
            var ex = Record.Exception(valid);
            Assert.Null(ex);
        }

        [Fact]
        public void Invalid()
        {
            void valid() => GenerateModel.PokemonViewModelInvalid.Valid();
            var ex = Record.Exception(valid);
            Assert.NotNull(ex);
        }
    }
}
