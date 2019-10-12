using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CustomerListViewModel
    {
        public IEnumerable<CustomerDto> Customers { get; set; }

        public CustomerListViewModel()
        {
        }

        public CustomerListViewModel(IEnumerable<CustomerDto> customersDto)
        {
            this.Customers = customersDto;
        }
    }
}
