using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PracticalTask.Domain.Commands;
using PracticalTask.Domain.Core.Bus;
using PracticalTask.Domain.Core.Notifications;
using PracticalTask.Domain.Events;
using PracticalTask.Domain.Interfaces;
using PracticalTask.Domain.Models;

namespace PracticalTask.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<AddNewCustomerCommand>,
        IRequestHandler<UpdateCustomerCommand>,
        IRequestHandler<RemoveCustomerCommand>,
        IRequestHandler<SoftRemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public Task Handle(AddNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var customer = new Customer(Guid.NewGuid(), message.Name, message.IsActive);

            if (_customerRepository.GetByName(customer.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer name has already been exists."));
                return Task.CompletedTask;
            }

            _customerRepository.Add(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerAddedEvent(customer.Id, customer.Name, customer.IsActive));
            }

            return Task.CompletedTask;
        }

        public Task Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var customer = new Customer(message.Id, message.Name, message.IsActive);
            var existingCustomer = _customerRepository.GetByName(customer.Name);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer name has already been exists."));
                    return Task.CompletedTask;
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.IsActive));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }



        public Task Handle(SoftRemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }



            _customerRepository.SoftRemove(message.Id);

            if (Commit())
            {
                var existingCustomer = _customerRepository.GetById(message.Id);

                Bus.RaiseEvent(new CustomerUpdatedEvent(existingCustomer.Id, existingCustomer.Name, existingCustomer.IsActive));
            }

            return Task.CompletedTask;
        }

    }
}