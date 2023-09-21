using Domain.Services.AdapterInterface;
using Domain.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PokemonService : IPokemonService 
    {
        private readonly IPokemonApi _pokemonApi;

        public PokemonService(IPokemonApi pokemonApi)
        {
            _pokemonApi = pokemonApi;
        }

        public Task<PokemonStatus> PokemonInformation(string name)
        {
           return _pokemonApi.PokemonInformation(name);
        }
    }
}
