using System;
using System.Collections.Generic;
using PracticalTask.Application.EventSourcedNormalizers;
using PracticalTask.Application.ViewModels;

namespace PracticalTask.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        void SoftRemove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
