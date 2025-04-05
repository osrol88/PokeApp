using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PokeApiApp.Domain.Entity;
using PokeApiApp.Infrastructure.Entity;
using System.Data;
using System.Text.Json;


namespace PokeApiApp.Infrastructure.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IDbConnection _db;

        public PokemonRepository(IConfiguration config)
        {
            _db = new SqlConnection(config.GetConnectionString("pokeConn"));
        }

        public async Task<Pokemon?> GetByName(string name)
        {
            var sql = "SELECT * FROM pokemon WHERE nombre = @Nombre";
            var entity = await _db.QueryFirstOrDefaultAsync<PokemonEntity>(sql, new { Nombre = name });

            return entity == null ? null : new Pokemon
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Altura = entity.Altura,
                Peso = entity.Peso,
                Tipos = JsonSerializer.Deserialize<List<string>>(entity.Tipos)!,
                ImagenUrl = entity.ImagenUrl,
            };
        }

        public async Task Save(Pokemon pokemon)
        {
            var sql = @"INSERT INTO pokemon (id, nombre, altura, peso, tipos,imagenUrl)
                    VALUES (@Id, @Nombre, @Altura, @Peso, @Tipos,@imagenUrl)";
            await _db.ExecuteAsync(sql, new
            {
                pokemon.Id,
                pokemon.Nombre,
                pokemon.Altura,
                pokemon.Peso,
                Tipos = JsonSerializer.Serialize(pokemon.Tipos),
                pokemon.ImagenUrl
            });
        }
    }

}
