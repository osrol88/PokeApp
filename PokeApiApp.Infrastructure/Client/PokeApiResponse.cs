using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeApiApp.Infrastructure.Client
{
    public class PokeApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokeTypeWrapper> Types { get; set; }
        public sprites Sprites { get; set; } = new();
    }

    public class PokeTypeWrapper
    {
        public PokeType Type { get; set; }
    }

    public class PokeType
    {
        public string Name { get; set; }
    }

    public class sprites
    {
        public string front_default { get; set; } = string.Empty;
    }
}
