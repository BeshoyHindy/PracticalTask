using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PracticalTask.Application.Interfaces;
using PracticalTask.Application.Services;
using PracticalTask.Domain.CommandHandlers;
using PracticalTask.Domain.Commands;
using PracticalTask.Domain.Core.Bus;
using PracticalTask.Domain.Core.Events;
using PracticalTask.Domain.Core.Notifications;
using PracticalTask.Domain.EventHandlers;
using PracticalTask.Domain.Events;
using PracticalTask.Domain.Interfaces;
using PracticalTask.Infra.CrossCutting.Bus;
using PracticalTask.Infra.Data.Context;
using PracticalTask.Infra.Data.EventSourcing;
using PracticalTask.Infra.Data.Repository;
using PracticalTask.Infra.Data.Repository.EventSourcing;
using PracticalTask.Infra.Data.UoW;

namespace PracticalTask.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerAddedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PracticalTaskContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}
