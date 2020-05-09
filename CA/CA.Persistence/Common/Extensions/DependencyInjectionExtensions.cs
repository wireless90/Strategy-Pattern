using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CA.Persistence.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceInjections(this IServiceCollection services)
        {
            services.AddDbContext<PersonDbContext>(options => options.UseSqlServer("myrealconnectionstring"));
            return services;
        }
    }
}
