using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerDto Customer { get; set; }

        public CustomerViewModel()
        {
        }
        public CustomerViewModel(CustomerDto customerDto)
        {
            this.Customer = customerDto;
        }
    }
}
