using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiApp.Domain.Entity
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public List<string> Tipos { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
