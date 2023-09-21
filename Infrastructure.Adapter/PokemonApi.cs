using Domain.Services.AdapterInterface;
using Domain.Services.Model;
using Infrastructure.Adapter.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Adapter
{
    public class PokemonApi : IPokemonApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseurl = "https://pokeapi.co/api/v2/";
        
        public PokemonApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonStatus> PokemonInformation(string name)
        {
            var url = $"{_baseurl}pokemon/{name.ToLower()}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var responsebody = await response.Content.ReadAsStringAsync();
            var information = JsonConvert.DeserializeObject<PokemonStatusResponse>(responsebody);

            return information.ToPokemonStatus();
        }

    }
}
