using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.ServicesAbstractions;
using PokemonAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IPokemonService PokemonService = null;

        public PokemonController(IPokemonService pokemonService)
        {
            PokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await PokemonService.GetAllAsync();
                if (result == null || !result.Any())
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await PokemonService.GetByIdAsync(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PokemonViewModel pokemonViewModel)
        {
            try
            {
                var pokemon = new Pokemon(pokemonViewModel);
                await PokemonService.SaveAsync(pokemon);
                return CreatedAtAction("Create", pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateMany(IList<PokemonViewModel> pokemonViewModels)
        {
            try
            {
                IList<Pokemon> pokemons = new List<Pokemon>();
                foreach (var pokemonViewModel in pokemonViewModels)
                    pokemons.Add(new Pokemon(pokemonViewModel));
               
                await PokemonService.SaveAsync(pokemons);
                return CreatedAtAction("Create", pokemons);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PokemonViewModel pokemonViewModel)
        {
            try
            {
                var pokemon = new Pokemon(pokemonViewModel, id);
                await PokemonService.UpdateAsync(pokemon);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateMany")]
        public async Task<IActionResult> UpdateMany(IList<PokemonUpdateViewModel> pokemonViewModels)
        {
            try
            {
                IList<Pokemon> pokemons = new List<Pokemon>();
                foreach (var pokemonViewModel in pokemonViewModels)
                    pokemons.Add(new Pokemon(pokemonViewModel, pokemonViewModel.Id));

                await PokemonService.UpdateAsync(pokemons);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await PokemonService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteMany")]
        public async Task<IActionResult> DeleteMany(IList<Guid> ids)
        {
            try
            {
                await PokemonService.DeleteAsync(ids);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}