using Domain.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AdapterInterface
{
    public interface IPokemonApi
    {
        Task<PokemonStatus> PokemonInformation(string name);
    }
}
