using AutoMapper;
using PracticalTask.Application.ViewModels;
using PracticalTask.Domain.Commands;

namespace PracticalTask.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, AddNewCustomerCommand>()
                .ConstructUsing(c => new AddNewCustomerCommand(c.Name, c.IsActive));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.IsActive));
        }
    }
}
