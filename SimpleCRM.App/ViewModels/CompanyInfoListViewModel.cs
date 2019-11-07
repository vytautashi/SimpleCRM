using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CompanyInfoListViewModel
    {
        public IEnumerable<CompanyInfoDto> CompaniesInfo { get; set; }

        public CompanyInfoListViewModel()
        {
        }

        public CompanyInfoListViewModel(IEnumerable<CompanyInfoDto> companiesInfoDto)
        {
            this.CompaniesInfo = companiesInfoDto;
        }
    }
}
