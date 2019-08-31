using CommandAPI.Models;
using CommandAPI.ServicesAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IPokemonService PokemonService = null;

        public PokemonController(IPokemonService pokemonService)
        {
            PokemonService = pokemonService;
        }


        //GET:      api/commands
        [HttpGet]
        public IActionResult GetCommandItems() => Ok();

        //GET:      api/commands/n
        [HttpGet("{id}")]

        public IActionResult GetCommandItem(int id)
        {
            var result = PokemonService.AlterarTodoCodigoDiego();
            return Ok(result);
        }

        //POST:     api/commands
        [HttpPost]
        public IActionResult PostCommandItem(Pokemon command)
        {
            return CreatedAtAction("GetCommandItem", new Pokemon { Id = command.Id }, command);
        }

        //PUT:      api/commands/n
        [HttpPut("{id}")]
        public IActionResult PutCommandItem(int id, Pokemon command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //DELETE:   api/commands/n
        [HttpDelete("{id}")]
        public IActionResult DeleteCommandItem(int id)
        {
           return NotFound(id); 
        }
    }
}