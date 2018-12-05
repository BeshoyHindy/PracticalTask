using System;
using PracticalTask.Domain.Core.Events;

namespace PracticalTask.Domain.Events
{
    public class CustomerAddedEvent : Event
    {
        public CustomerAddedEvent(Guid id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public bool IsActive { get; private set; }

    }
}