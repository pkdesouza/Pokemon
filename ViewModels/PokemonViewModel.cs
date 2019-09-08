using System;
using System.Collections.Generic;

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
    }
    public class PokemonUpdateViewModel : PokemonViewModel {
        public Guid Id { get; set; }
    }
}
