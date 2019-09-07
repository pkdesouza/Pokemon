using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using PokemonAPI.ServicesAbstractions;
using System;
using System.Collections.Generic;
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
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = await PokemonService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pokemon pokemon)
        {
            try
            {
                await PokemonService.SaveAsync(pokemon);
                return CreatedAtAction("Create", pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateMany(IList<Pokemon> pokemons)
        {
            try
            {
                await PokemonService.SaveAsync(pokemons);
                return CreatedAtAction("Create", pokemons);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Pokemon pokemon)
        {
            try
            {
                await PokemonService.UpdateAsync(pokemon);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateMany/{ids}")]
        public async Task<IActionResult> UpdateMany(string ids, IList<Pokemon> pokemon)
        {
            try
            {
                await PokemonService.UpdateAsync(pokemon);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await PokemonService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteMany/{ids}")]
        public async Task<IActionResult> DeleteMany(IList<string> ids)
        {
            try
            {
                await PokemonService.DeleteAsync(ids);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}