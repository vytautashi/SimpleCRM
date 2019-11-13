using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CompanyInfoViewModel
    {
        public CompanyInfoDto CompanyInfo { get; set; }

        public CompanyInfoViewModel()
        {
        }
        public CompanyInfoViewModel(CompanyInfoDto companyInfoDto)
        {
            this.CompanyInfo = companyInfoDto;
        }
    }
}
