using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public static class CustomerConverter
    {
        public static CustomerDto ToCustomerDto(Customer customer)
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

        public static CustomerListViewModel ToCustomerListViewModel(IEnumerable<Customer> customers)
        {
            Collection<CustomerDto> customersDto = new Collection<CustomerDto>();

            foreach (var customer in customers)
            {
                customersDto.Add(ToCustomerDto(customer));
            }

            return new CustomerListViewModel { Customers = customersDto };
        }

        public static CustomerViewModel ToCustomerViewModel(Customer customer)
        {
            CustomerDto customerDto = ToCustomerDto(customer);

            return new CustomerViewModel { Customer = customerDto };
        }

    }
}
