using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiApp.Infrastructure.Entity
{
    public class PokemonEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public string Tipos { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
