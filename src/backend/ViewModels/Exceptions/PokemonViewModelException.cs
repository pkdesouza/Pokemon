using System;

namespace PokemonAPI.ViewModels
{
    public class PokemonViewModelException : Exception
    {
        public PokemonViewModelException(string message) : base(message)
        {
        }
    }
}
