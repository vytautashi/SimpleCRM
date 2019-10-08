using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.App.Dto;

namespace SimpleCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            CustomerDto[] customers =
            {
                new CustomerDto
                {
                    Id = 1,
                    Email = "all.ignas80@yahoo.com",
                    FullName = "Ignas D.",
                    Phone = "862345222",
                    LastContacted = DateTime.Today,
                    ActiveAds = 7,
                    OpenIssue = 1,
                },
                new CustomerDto
                {
                    Id = 2,
                    Email = "j.jonas@gmail.com",
                    FullName = "Jonas Jonaitis",
                    Phone = "864233552",
                    LastContacted = DateTime.Now,
                    ActiveAds = 1,
                    OpenIssue = 0,
                },
            };
            customerViewModel.Customers = customers.ToList();
            return Ok(customerViewModel);
        }
    }
}