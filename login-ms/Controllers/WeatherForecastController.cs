using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using Presentation.Application.Controllers.Model;
using Domain.Services;
using System.Threading.Tasks;
using Domain.Services.Model;

namespace Presentation.Application.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPokemonService _pokemonService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("/OlaPrimeiroNome")]
        public string OlaPrimeiroNome([FromBody] modelopayload payload)
        {
            _ = OlaBuilder(payload);
            return OlaBuilder(payload);

        }

        [HttpPost("/PokemonInformation")]
        public Task<PokemonStatus> PokemonInformation([FromBody] string name)
        {
            return _pokemonService.PokemonInformation(name);
        }

        private static string OlaBuilder(modelopayload payload)
        {
            var numeroDeFeriados = CountHolidays(payload.Ano);
            if (numeroDeFeriados < 4)
                return $"Olá {payload.Nome}, no ano do seu nascimento houveram poucos feriados";

            return $"Olá {payload.Nome}, no ano do seu nascimento houveram {numeroDeFeriados} feriados";
        }

        private static int CountHolidays(int year)
        {
            List<DateTime> holidays = new List<DateTime>
        {
            new DateTime(year, 1, 1),   // Ano Novo
            new DateTime(year, 7, 4),   // Dia da Independência
            new DateTime(year, 12, 25), // Natal
            // Adicione outros feriados aqui
        };

            // Adicione mais feriados conforme necessário

            int count = 0;

            foreach (DateTime holiday in holidays)
            {
                if (holiday.Year == year)
                {
                    count++;
                }
            }

            return count;
        }
    }
}