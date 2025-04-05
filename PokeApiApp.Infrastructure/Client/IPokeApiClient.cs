using Refit;

namespace PokeApiApp.Infrastructure.Client
{
    public interface IPokeApiClient
    {
        [Get("/pokemon/{name}")]
        Task<PokeApiResponse> GetPokemon(string name);
    }
}
