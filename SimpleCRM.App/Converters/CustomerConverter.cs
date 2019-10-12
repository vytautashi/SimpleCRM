using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public class CustomerConverter : GenericConverter<Customer, CustomerDto>
    {
        public override CustomerDto ToDto(Customer customer)
        {
            CustomerDto customerDto = new CustomerDto
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone,
                LastContacted = customer.LastContacted,
                ActiveAds = customer.ActiveAds,
                OpenIssue = customer.OpenIssue,
            };
            return customerDto;
        }

        public CustomerListViewModel ToCustomerListViewModel(IEnumerable<Customer> customers)
        {
            return new CustomerListViewModel(ToDtoList(customers));
        }

        public CustomerViewModel ToCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel(ToDto(customer));
        }


    }
}
