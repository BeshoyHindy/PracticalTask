using System;
using PracticalTask.Domain.Models;

namespace PracticalTask.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByName(string name);
        void SoftRemove(Guid id);
    }
}