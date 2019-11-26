using SimpleCRM.App.Dto;
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
                CompanyCode = companyDto.CompanyCode,
                Name = companyDto.Name,
                Address = companyDto.Address,
                Ceoname = companyDto.Ceoname,
                Website = companyDto.Website,
                Phone = companyDto.Phone,
            };
            return company;
        }

        public override CompanyDto ToDto(Company company)
        {
            CompanyDto companyDto = new CompanyDto
            {
                Id = company.Id,
                CompanyCode = company.CompanyCode,
                Name = company.Name,
                Address = company.Address,
                Ceoname = company.Ceoname,
                Website = company.Website,
                Phone = company.Phone,
            };
            return companyDto;
        }
    }
}
