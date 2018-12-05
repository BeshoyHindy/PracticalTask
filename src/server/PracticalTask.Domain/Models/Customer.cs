using System;
using PracticalTask.Domain.Core.Models;

namespace PracticalTask.Domain.Models
{
    public class Customer : Entity
    {
        public Customer(Guid id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }

        public bool IsActive { get; private set; }

        public void Activate()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }

    }
}