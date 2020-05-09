using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureInjections(this IServiceCollection services)
        {

            return services;
        }
    }
}
