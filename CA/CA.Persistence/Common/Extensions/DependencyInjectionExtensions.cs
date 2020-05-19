using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CA.Persistence.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceInjections(this IServiceCollection services)
        {
            services.AddDbContext<PersonDbContext>(options => 
            options.UseSqlServer(@"Data Source=DESKTOP-S0OLDPR\SQLEXPRESS;Initial Catalog=VidlyDB;Integrated Security=True"));

            return services;
        }
    }
}
