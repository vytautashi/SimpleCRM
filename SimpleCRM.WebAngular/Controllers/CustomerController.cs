using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Dto;

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
                    Email = "ignas80@yahoo.com",
                    FullName = "Ignas Ignaitis",
                    Phone = "862345222",
                    LastContacted = DateTime.Today,
                    ActiveAds = 7,
                },
                new CustomerDto
                {
                    Id = 2,
                    Email = "jonas@gmail.com",
                    FullName = "Jonas Jonaitis",
                    Phone = "864233552",
                    LastContacted = DateTime.Now,
                    ActiveAds = 1,
                },
            };
            customerViewModel.Customers = customers.ToList();
            return Ok(customerViewModel);
        }
    }
}