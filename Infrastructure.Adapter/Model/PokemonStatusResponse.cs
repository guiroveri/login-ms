using Domain.Services.Model;

namespace Infrastructure.Adapter.Model
{
    public class PokemonStatusResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public PokemonStatus ToPokemonStatus()
        {
            return new PokemonStatus
            {
                name = this.name,
                height = this.height,
                weight = this.weight
            };
        }
    }
}
