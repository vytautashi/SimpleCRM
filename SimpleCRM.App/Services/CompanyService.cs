using SimpleCRM.App.Converters;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Helpers;
using SimpleCRM.App.Interfaces;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private CompanyConverter _companyConverter;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _companyConverter = new CompanyConverter();
        }

        public async Task<bool> AddCompanyAsync(CompanyDto company)
        {
            // TODO validation
            Company companyTemp = _companyConverter.ToCompany(company);
            bool companyValid = companyTemp.Name.Length > 0; // TODO validation
            if (companyValid)
            {
                await _companyRepository.AddAsync(companyTemp);
            }
            return companyValid;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            if (await _companyRepository.ExistsAsync(id))
            {
                await _companyRepository.DeleteAsync(id);
            }
        }

        public async Task<CompanyDto> GetCompanyAsync(int id)
        {
            if (!await _companyRepository.ExistsAsync(id))
            {
                return new CompanyDto();
            }

            Company company = await _companyRepository.GetAsync(id);

            return _companyConverter.ToDto(company);
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanyListAsync()
        {
            IEnumerable<Company> companies = await _companyRepository.GetListAsync();

            return _companyConverter.ToDtoList(companies);
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanyListSearchAsync(string search)
        {
            // TODO validation
            IEnumerable<Company> companies = await _companyRepository.GetListAsyncSearch(search);

            return _companyConverter.ToDtoList(companies);
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanyListSortAsync(string sort)
        {
            // TODO validation
            IEnumerable<Company> companies = await _companyRepository.GetListAsyncSort(sort);

            return _companyConverter.ToDtoList(companies);
        }

        public async Task UpdateCompanyAsync(int id, CompanyDto company)
        {
            // TODO validation
            Company companyTemp = _companyConverter.ToCompany(company);
            if (await _companyRepository.ExistsAsync(id))
            {
                companyTemp.Id = id;
                await _companyRepository.UpdateAsync(companyTemp);
            }
        }

        public async Task<IEnumerable<CompanyInfoDto>> GetCompanyExternal(string companyCode)
        {
            return await MyParser.CompanyByCode(companyCode);
        }

        public async Task<IEnumerable<CompanyInfoDto>> GetCompanyExternalByTitle(string title)
        {
            return await MyParser.CompanyByTitle(title);
        }

        public async Task<CompanyInfoDto> GetCompanyExternalDetails(string url)
        {
            return await MyParser.CompanyByUrl(url);
        }
    }
}
