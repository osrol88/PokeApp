using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using PokeApiApp.Application.Service;
using PokeApiApp.Domain.Entity;

public class IndexModel : PageModel
{
    private readonly PokemonService _service;

    public IndexModel(PokemonService service)
    {
        _service = service;
    }

    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }

    public Pokemon? Pokemon { get; set; }

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            Pokemon = await _service.GetPokemon(Name.ToLower());
        }
    }
}
