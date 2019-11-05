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
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Company>> GetListAsyncSearch(string search)
        {
            IQueryable<Company> query = _context.Companies;

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search)
                    || c.Ceoname.Contains(search));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetListAsyncSort(string sort)
        {
            IQueryable<Company> query = _context.Companies;
            switch (sort)
            {
                case "name":
                    query = query.OrderBy(c => c.Name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(c => c.Name);
                    break;
                case "ceoname":
                    query = query.OrderBy(c => c.Ceoname);
                    break;
                case "ceoname_desc":
                    query = query.OrderByDescending(c => c.Ceoname);
                    break;
            }
            return await query.ToListAsync();
        }
    }
}
