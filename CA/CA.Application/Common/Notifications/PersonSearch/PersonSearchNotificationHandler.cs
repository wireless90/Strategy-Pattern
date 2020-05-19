using Autofac;
using CA.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.Common.Notifications.PersonSearch
{
    public class PersonSearchNotificationHandler : INotificationHandler<PersonSearchNotification>
    {
        private IPersonDbContext _personDbContext;
        private readonly ILifetimeScope _lifetimeScope;

        public PersonSearchNotificationHandler(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public Task Handle(PersonSearchNotification notification, CancellationToken cancellationToken)
        {
            Task.Run(() => ParallelNoWait());

            return Task.CompletedTask;
        }

        private Task ParallelNoWait()
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                _personDbContext = scope.Resolve<IPersonDbContext>();
                
                Task.Delay(5000).Wait();

                Log.Debug("testing before");

                try
                {
                    var x = _personDbContext.Persons.SingleOrDefaultAsync(p => p.Id == 2);

                    Log.Debug("testing afterrrrr {@x}", x);
                }
                catch (System.Exception e)
                {

                    Log.Error(e, "GG");
                }
            }

            return Task.CompletedTask;
        }
    }
}
