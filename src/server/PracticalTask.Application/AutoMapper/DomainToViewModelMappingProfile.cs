using AutoMapper;
using PracticalTask.Application.ViewModels;
using PracticalTask.Domain.Models;

namespace PracticalTask.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
