﻿using PokemonAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPI.ServicesAbstractions
{
    public interface IPokemonService
    {
        Task<IEnumerable<Pokemon>> GetAllPokemons();
    }

}

