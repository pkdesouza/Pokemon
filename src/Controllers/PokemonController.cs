using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.ServicesAbstractions;
using PokemonAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<IActionResult> GetAllAsync()
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

        public async Task<IActionResult> GetByIdAsync(Guid id)
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
        public async Task<IActionResult> CreateAsync(PokemonViewModel pokemonViewModel)
        {
            try
            {
                pokemonViewModel.Valid();
                var pokemon = new Pokemon(pokemonViewModel);
                await PokemonService.SaveAsync(pokemon);
                return CreatedAtAction("Create", pokemon);
            }
            catch (PokemonViewModelException e)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateManyAsync(IList<PokemonViewModel> pokemonViewModels)
        {
            try
            {
                IList<Pokemon> pokemons = new List<Pokemon>();
                foreach (var pokemonViewModel in pokemonViewModels)
                {
                    pokemonViewModel.Valid();
                    pokemons.Add(new Pokemon(pokemonViewModel));
                }
               
                await PokemonService.SaveAsync(pokemons);
                return CreatedAtAction("Create", pokemons);
            }
            catch (PokemonViewModelException e)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, PokemonViewModel pokemonViewModel)
        {
            try
            {
                pokemonViewModel.Valid();
                var pokemon = new Pokemon(pokemonViewModel, id);
                await PokemonService.UpdateAsync(pokemon);
                return Ok();
            }
            catch(PokemonViewModelException e)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateMany")]
        public async Task<IActionResult> UpdateManyAsync(IList<PokemonUpdateViewModel> pokemonViewModels)
        {
            try
            {
                IList<Pokemon> pokemons = new List<Pokemon>();
                foreach (var pokemonViewModel in pokemonViewModels)
                {
                    pokemonViewModel.Valid();
                    pokemons.Add(new Pokemon(pokemonViewModel, pokemonViewModel.Id));
                }

                await PokemonService.UpdateAsync(pokemons);
                return Ok();
            }
            catch (PokemonViewModelException e)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
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
        public async Task<IActionResult> DeleteManyAsync(IList<Guid> ids)
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