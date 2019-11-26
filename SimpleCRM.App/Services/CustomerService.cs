using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.Converters;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private CustomerConverter _customerConverter;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _customerConverter = new CustomerConverter();
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            if (!await _customerRepository.ExistsAsync(id))
            {
                return new CustomerDto();
            }

            Customer customer = await _customerRepository.GetAsync(id);

            return _customerConverter.ToDto(customer);
        }

        public async Task<CustomerDto> GetCustomerByPhoneAsync(string phoneNumber)
        {
            if (phoneNumber == null || phoneNumber.Equals(""))
            {
                return new CustomerDto();
            }
            Customer customer = await _customerRepository.GetByPhoneAsync(phoneNumber);
            if (customer == null)
            {
                return new CustomerDto();
            }

            return _customerConverter.ToDto(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomerListAsync()
        {
            IEnumerable<Customer> customers = await _customerRepository.GetListAsync();

            return _customerConverter.ToDtoList(customers);
        }
    }
}
