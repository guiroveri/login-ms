using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
