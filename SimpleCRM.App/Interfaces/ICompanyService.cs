using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCRM.App.Dto;

namespace SimpleCRM.App.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetCompanyListSearchAsync(string search);
        Task<IEnumerable<CompanyDto>> GetCompanyListSortAsync(string sort);
        Task<IEnumerable<CompanyInfoDto>> GetCompanyExternal(string companyCode);
        Task<IEnumerable<CompanyInfoDto>> GetCompanyExternalByTitle(string title);
        Task<CompanyInfoDto> GetCompanyExternalDetails(string url);

        Task<IEnumerable<CompanyDto>> GetCompanyListAsync();
        Task<CompanyDto> GetCompanyAsync(int id);
        Task<bool> AddCompanyAsync(CompanyDto company);
        Task DeleteCompanyAsync(int id);
        Task UpdateCompanyAsync(int id, CompanyDto company);
    }
}
