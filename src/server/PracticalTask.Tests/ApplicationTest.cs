using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PracticalTask.Application.Interfaces;
using PracticalTask.Application.ViewModels;
using PracticalTask.Domain.Models;

namespace PracticalTask.Tests
{
    [TestClass]
    public class ApplicationTest
    {

        private readonly ICustomerAppService _customerAppService;

        public ApplicationTest(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        [TestMethod]
        public void GetCustomersTest()
        {
            var mockRepo = new Mock<ICustomerAppService>();

            var customerId = new Guid("f82b1838-c8a8-4ee4-a272-a6ee8239e7b1");
            var newCustomer = new CustomerViewModel
            {
                Id = customerId,
                Name = "Test Customer",
                IsActive = true

            };

            mockRepo.Setup(app => app.GetById(customerId)).Returns(newCustomer);
            var item = _customerAppService.GetById(customerId);
            var result = item.Id;

            Assert.AreEqual(customerId, result);
        }


        [TestMethod]
        public void AddNewCustomersTest()
        {
            var mockRepo = new Mock<ICustomerAppService>();
            var customerId = new Guid("f82b1838-c8a8-4ee4-a272-a6ee8239e7b1");
            var newCustomer = new CustomerViewModel
            {
                Id = customerId,
                Name = "Test Customer",
                IsActive = true

            };

            mockRepo.Setup(app => app.Register(newCustomer));

            var list = new List<CustomerViewModel>();
            var result = list.Count;
            Assert.AreEqual(0, result);
        }
    }
}
