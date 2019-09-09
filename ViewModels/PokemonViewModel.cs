using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAPI.ViewModels
{
    public class PokemonViewModel
    {

        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Height { get; set; }
        public int Hp { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public List<string> Types { get; set; }

        public void Valid()
        {
            if (!(Attack > 0 && Attack < 1000))
                throw new PokemonViewModelException($"O {nameof(Attack)} está com valores inválidos");
            if (!(Defense > 0 && Defense < 1000))
                throw new PokemonViewModelException($"O {nameof(Defense)} está com valores inválidos");
            if (string.IsNullOrEmpty(Height))
                throw new PokemonViewModelException($"O {nameof(Height)} não pode ser nulo");
            if (!(Hp > 0 && Hp < 1000))
                throw new PokemonViewModelException($"O {nameof(Hp)} está com valores inválidos");
            if (!(Speed > 0 && Speed < 1000))
                throw new PokemonViewModelException($"O {nameof(Speed)} está com valores inválidos");
            if (!Types?.Any() ?? true)
                throw new PokemonViewModelException($"O {nameof(Types)} não pode ser nulo ou vazio");
        }
    }

}
