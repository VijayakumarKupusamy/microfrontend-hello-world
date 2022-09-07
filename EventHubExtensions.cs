using Core.Services.Events.Mediatr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Events
{
    public static class EventHubExtensions
    {
        public static IServiceCollection AddEventHub(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);

            services.AddTransient<IDomainEventDispatcher, MediatrDomainEventDispatcher>();

            return services;
        }
    }
}
