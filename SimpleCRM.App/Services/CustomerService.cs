using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.App.Converters;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> GetCustomerAsync(int id)
        {
            if (!await _customerRepository.ExistsAsync(id))
            {
                return new CustomerViewModel();
            }

            Customer customer = await _customerRepository.GetAsync(id);

            return CustomerConverter.ToCustomerViewModel(customer);
        }

        public async Task<CustomerViewModel> GetCustomerByPhoneAsync(string phoneNumber)
        {
            if (phoneNumber == null || phoneNumber.Equals(""))
            {
                return new CustomerViewModel();
            }
            Customer customer = await _customerRepository.GetByPhoneAsync(phoneNumber);
            if (customer == null)
            {
                return new CustomerViewModel();
            }

            return CustomerConverter.ToCustomerViewModel(customer);
        }

        public async Task<CustomerListViewModel> GetCustomerListAsync()
        {
            IEnumerable<Customer> customers = await _customerRepository.GetListAsync();

            return CustomerConverter.ToCustomerListViewModel(customers);
        }
    }
}
