using System;
using PracticalTask.Domain.Core.Commands;

namespace PracticalTask.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public bool IsActive { get; protected set; }

    }
}