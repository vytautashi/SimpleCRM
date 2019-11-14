using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CompanyListViewModel
    {
        public IEnumerable<CompanyDto> Companies { get; set; }

        public CompanyListViewModel()
        {
        }

        public CompanyListViewModel(IEnumerable<CompanyDto> companiesDto)
        {
            this.Companies = companiesDto;
        }
    }
}
