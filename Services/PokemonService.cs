using CommandAPI.Models;
using CommandAPI.ServicesAbstractions;

namespace CommandAPI.Services
{
    public class PokemonService : IPokemonService
    {
        public Pokemon AlterarTodoCodigoDiego()
        {
            return new Pokemon
            {
                Commandline = "sei lá",
                Howto = "Vc me deve 50 conto",
                Platform = "vou cobrar",
                Id = 1
            };
        }
    }
}
