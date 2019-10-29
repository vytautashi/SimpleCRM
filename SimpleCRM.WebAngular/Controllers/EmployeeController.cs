using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;

namespace SimpleCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmpoyeeService _empoyeeService;

        public EmployeeController(IEmpoyeeService empoyeeService)
        {
            _empoyeeService = empoyeeService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int id = Int32.Parse(identity.FindFirst("sub").Value);

            return Ok(await _empoyeeService.GetEmployeeAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _empoyeeService.GetEmployeeListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _empoyeeService.GetEmployeeAsync(id);

            if (employee.Employee != null)
                return Ok(employee);
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(EmployeeViewModel employee)
        {
            bool success = await _empoyeeService.AddEmployeeAsync(employee);
            if (success)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmployeeViewModel employee)
        {
            await _empoyeeService.UpdateEmployeeAsync(id, employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empoyeeService.DeleteEmployeeAsync(id);

            return NoContent();
        }
    }
}