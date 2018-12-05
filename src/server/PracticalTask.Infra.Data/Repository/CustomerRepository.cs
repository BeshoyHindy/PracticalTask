using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PracticalTask.Domain.Interfaces;
using PracticalTask.Domain.Models;
using PracticalTask.Infra.Data.Context;

namespace PracticalTask.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PracticalTaskContext context)
            : base(context)
        {

        }

        public Customer GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

        public void SoftRemove(Guid id)
        {
            var customer = DbSet.Find(id);
            customer.Deactivate();
            Update(customer);
            SaveChanges();
        }
    }
}
