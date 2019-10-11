using Microsoft.EntityFrameworkCore;
using SimpleCRM.Data.Context;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        public async Task<Customer> GetByPhoneAsync(string phoneNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Phone.Equals(phoneNumber));
        }
    }
}
