using SimpleCRM.Data.Models;
using SimpleCRM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerListViewModel> GetCustomerListAsync();
        Task<CustomerViewModel> GetCustomerAsync(int id);
        Task<CustomerViewModel> GetCustomerByPhoneAsync(string phoneNumber);
    }
}
