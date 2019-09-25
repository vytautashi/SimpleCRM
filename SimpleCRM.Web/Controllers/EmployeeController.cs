using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Data.Models;
using SimpleCRM.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SimpleCRMContext _context;

        public EmployeeController(SimpleCRMContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = new EmployeeDto[]{
                new EmployeeDto{EmployeeId = 1, FirstName = "Antanas", LastName = "Antanauskas", Connected = true},
                new EmployeeDto{EmployeeId = 2, FirstName = "Jonas",LastName = "Jonauskas", Connected = false},
                };

            return Ok(employees);
            //_context.Employees.Add(new Employee { FirstName = "Antanas",LastName = "Jo" });
            //_context.SaveChanges();
            //return await _context.Employees.ToListAsync();
        }

    }
}