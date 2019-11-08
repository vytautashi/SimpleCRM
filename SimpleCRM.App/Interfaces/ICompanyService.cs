using SimpleCRM.Data.Models;
using SimpleCRM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyListViewModel> GetCompanyListSearchAsync(string search);
        Task<CompanyListViewModel> GetCompanyListSortAsync(string sort);
        Task<CompanyInfoListViewModel> GetCompanyExternal(string companyCode);
        Task<CompanyInfoListViewModel> GetCompanyExternalByTitle(string title);

        Task<CompanyListViewModel> GetCompanyListAsync();
        Task<CompanyViewModel> GetCompanyAsync(int id);
        Task<bool> AddCompanyAsync(CompanyViewModel company);
        Task DeleteCompanyAsync(int id);
        Task UpdateCompanyAsync(int id, CompanyViewModel company);
    }
}
