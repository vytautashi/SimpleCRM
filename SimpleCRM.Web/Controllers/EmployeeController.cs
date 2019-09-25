using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Data.Models;
using SimpleCRM.Data.Context;
using Microsoft.EntityFrameworkCore;
using SimpleCRM.Data.Repositories;

namespace SimpleCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
		private EmployeeRepository _employeeRepository;

        public EmployeeController(SimpleCRMContext context)
        {
			_employeeRepository = new EmployeeRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeRepository.GetEmployeeListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeRepository.GetEmployeeAsync(id));
        }

    }
}