using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public class CompanyConverter : GenericConverter<Company, CompanyDto>
    {
        public Company ToCompany(CompanyDto companyDto)
        {
            Company company = new Company
            {
                Id = companyDto.Id,
                Name = companyDto.Name,
                Address = companyDto.Address,
                Ceoname = companyDto.Ceoname,
                Website = companyDto.Website,
                Email = companyDto.Email,
                Phone = companyDto.Phone,
                Status = companyDto.Status,
            };
            return company;
        }

        public override CompanyDto ToDto(Company company)
        {
            CompanyDto companyDto = new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Ceoname = company.Ceoname,
                Website = company.Website,
                Email = company.Email,
                Phone = company.Phone,
                Status = company.Status,
            };
            return companyDto;
        }

        public CompanyListViewModel ToCompanyListViewModel(IEnumerable<Company> companies)
        {
            return new CompanyListViewModel(ToDtoList(companies));
        }

        public CompanyViewModel ToCompanyViewModel(Company company)
        {
            return new CompanyViewModel(ToDto(company));
        }



    }
}
