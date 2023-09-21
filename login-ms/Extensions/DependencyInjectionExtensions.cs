using Domain.Services;
using Domain.Services.AdapterInterface;
using Infrastructure.Adapter;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IPokemonApi, PokemonApi>();

            services.AddHttpClient();

            return services;
        }
    }
}
