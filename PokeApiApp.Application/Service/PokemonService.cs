using Azure;
using PokeApiApp.Domain.Entity;
using PokeApiApp.Infrastructure.Client;
using PokeApiApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiApp.Application.Service
{
    public class PokemonService
    {
        private readonly IPokemonRepository _repo;
        private readonly IPokeApiClient _client;

        public PokemonService(IPokemonRepository repo, IPokeApiClient client)
        {
            _repo = repo;
            _client = client;
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
             var local = await _repo.GetByName(name.ToLower().Trim());
             if (local != null) return local;

            var remote = await _client.GetPokemon(name.ToLower().Trim());

            var pokemon = new Pokemon
            {
                Id = remote.Id,
                Nombre = remote.Name,
                Altura = remote.Height,
                Peso = remote.Weight,
                Tipos = remote.Types.Select(t => t.Type.Name).ToList(),
                ImagenUrl = remote.Sprites.front_default
            };

          await _repo.Save(pokemon);
            return pokemon;
        }
    }
}