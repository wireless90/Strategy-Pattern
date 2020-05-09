using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CA.Persistence.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceInjections(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
