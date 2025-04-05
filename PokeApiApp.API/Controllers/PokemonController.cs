using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeApiApp.Application.Service;

namespace PokeApiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _service;

        public PokemonController(PokemonService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _service.GetPokemon(name);
            return Ok(result);
        }
    }
}
