using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Events.Mediatr
{
    public abstract class DomainEventHandler<TDomainEvent> : INotificationHandler<DomainEventNotification<TDomainEvent>>
        where TDomainEvent:IDomainEvent
    {
        protected readonly ILogger<DomainEventHandler<TDomainEvent>> _log;

        public DomainEventHandler(ILogger<DomainEventHandler<TDomainEvent>> log)
        {
            _log = log;
        }

        public Task Handle(DomainEventNotification<TDomainEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            try
            {
                HandleEvent(domainEvent);

                return Task.CompletedTask;
            }
            catch (Exception exc)
            {
                _log.LogError(exc, "Error handling domain event {domainEvent}", domainEvent.GetType());
                throw;
            }
        }

        public abstract Task HandleEvent(TDomainEvent domainEvent);
    }
}
