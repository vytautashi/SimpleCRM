using SimpleCRM.App.Converters;
using SimpleCRM.App.Helpers;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<bool> AddCompanyAsync(CompanyViewModel company)
        {
            // TODO validation
            Company companyTemp = _companyConverter.ToCompany(company.Company);
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

        public async Task<CompanyViewModel> GetCompanyAsync(int id)
        {
            if (!await _companyRepository.ExistsAsync(id))
            {
                return new CompanyViewModel();
            }

            Company company = await _companyRepository.GetAsync(id);

            return _companyConverter.ToCompanyViewModel(company);
        }

        public async Task<CompanyListViewModel> GetCompanyListAsync()
        {
            IEnumerable<Company> companies = await _companyRepository.GetListAsync();

            return _companyConverter.ToCompanyListViewModel(companies);
        }

        public async Task<CompanyListViewModel> GetCompanyListSearchAsync(string search)
        {
            // TODO validation
            IEnumerable<Company> companies = await _companyRepository.GetListAsyncSearch(search);

            return _companyConverter.ToCompanyListViewModel(companies);
        }

        public async Task<CompanyListViewModel> GetCompanyListSortAsync(string sort)
        {
            // TODO validation
            IEnumerable<Company> companies = await _companyRepository.GetListAsyncSort(sort);

            return _companyConverter.ToCompanyListViewModel(companies);
        }

        public async Task UpdateCompanyAsync(int id, CompanyViewModel company)
        {
            // TODO validation
            Company companyTemp = _companyConverter.ToCompany(company.Company);
            if (await _companyRepository.ExistsAsync(id))
            {
                companyTemp.Id = id;
                await _companyRepository.UpdateAsync(companyTemp);
            }
        }

        public async Task<CompanyInfoListViewModel> GetCompanyExternal(string companyCode)
        {
            return new CompanyInfoListViewModel(await MyParser.CompanyByCode(companyCode));
        }

        public async Task<CompanyInfoListViewModel> GetCompanyExternalByTitle(string title)
        {
            return new CompanyInfoListViewModel(await MyParser.CompanyByTitle(title));
        }

        public async Task<CompanyInfoViewModel> GetCompanyExternalDetails(string url)
        {
            return new CompanyInfoViewModel(await MyParser.CompanyByUrl(url));
        }
    }
}
