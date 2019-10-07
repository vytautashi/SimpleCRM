using SimpleCRM.App.Dto;
using SimpleCRM.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
    }
}
