using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeApiApp.Application.Service;
using PokeApiApp.Domain.Entity;
using PokeApiApp.Infrastructure.Repository;
using Xunit;
using PokeApiApp.Infrastructure.Client;

namespace PokeApiApp.Tests
{
    public class PokemonServiceTests
    {
        [Fact]
        public async Task ObtenerPokemon_DevuelvePokemonCorrecto()
        {
            var repoMock = new Mock<IPokemonRepository>();
            repoMock.Setup(r => r.GetByName("pikachu"))
                    .ReturnsAsync(new Pokemon
                    {
                        Nombre = "Pikachu",
                        Altura = 4,
                        Peso = 60,
                        ImagenUrl = "https://imagen.com",
                        Tipos = new List<string> { "electric" }
                    });

            var clientMock = new Mock<IPokeApiClient>(); 

            var service = new PokemonService(repoMock.Object, clientMock.Object); 

            var result = await service.GetPokemon("pikachu");

        
            Assert.NotNull(result);
            Assert.Equal("Pikachu", result.Nombre);
            Assert.Equal(4, result.Altura);
            Assert.Equal("electric", result.Tipos[0]);
        }
    }
}
