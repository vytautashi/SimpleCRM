﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Interfaces;

namespace SimpleCRM.WebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _companyService.GetCompanyListAsync());
        }

        [Route("[action]/{companyCode}")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyExternal(string companyCode)
        {
            return Ok(await _companyService.GetCompanyExternal(companyCode));
        }
    }
}