using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyDto Company { get; set; }

        public CompanyViewModel()
        {
        }
        public CompanyViewModel(CompanyDto companyDto)
        {
            this.Company = companyDto;
        }
    }
}
