using PokemonAPI.Models;
using PokemonAPI.ServicesAbstractions;
using Microsoft.AspNetCore.Mvc;
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


        //GET:      api/commands
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await PokemonService.GetAllPokemons());

        //GET:      api/commands/n
        [HttpGet("{id}")]

        public async Task<IActionResult> GetCommandItem(int id)
        {
            return Ok(await PokemonService.GetAllPokemons());
        }

        //POST:     api/commands
        [HttpPost]
        public IActionResult PostCommandItem(Pokemon command)
        {
            return CreatedAtAction("GetCommandItem", command);
        }

        //PUT:      api/commands/n
        [HttpPut("{id}")]
        public IActionResult PutCommandItem(int id, Pokemon command)
        {
            return BadRequest();
        }

        //DELETE:   api/commands/n
        [HttpDelete("{id}")]
        public IActionResult DeleteCommandItem(int id)
        {
            return NotFound(id);
        }
    }
}