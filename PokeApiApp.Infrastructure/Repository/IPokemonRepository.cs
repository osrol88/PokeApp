using PokeApiApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApiApp.Infrastructure.Repository
{
    public interface IPokemonRepository
    {
        Task<Pokemon?> GetByName(string name);
        Task Save(Pokemon pokemon);
    }
}
