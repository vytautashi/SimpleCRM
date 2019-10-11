using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task DeleteAsync(int id);
        Task AddAsync(Customer dailyTask);
        Task UpdateAsync(Customer dailyTask);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Customer>> GetListAsync();
        Task<Customer> GetAsync(int id);

        Task<Customer> GetByPhoneAsync(string phoneNumber);
    }
}
