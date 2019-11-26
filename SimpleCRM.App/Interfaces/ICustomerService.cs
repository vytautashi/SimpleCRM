using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCRM.App.Dto;

namespace SimpleCRM.App.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomerListAsync();
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<CustomerDto> GetCustomerByPhoneAsync(string phoneNumber);
    }
}
