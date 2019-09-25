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
    public class TaskController : ControllerBase
    {
        private readonly SimpleCRMContext _context;

        public TaskController(SimpleCRMContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = new DailyTaskDto[]{
                new DailyTaskDto{DailyTaskId = 1, Title = "Sky web programming", Description = "",EmployeeId = 1, EmployeeFirstName = "Antanas", EmployeeLastName = "Antanauskas"},
                new DailyTaskDto{DailyTaskId = 2, Title = "Sky web testing", Description = "",EmployeeId = 1, EmployeeFirstName = "Antanas", EmployeeLastName = "Antanauskas"},
                new DailyTaskDto{DailyTaskId = 3, Title = "Sky web UI design", Description = "",EmployeeId = 2, EmployeeFirstName = "Jonas",EmployeeLastName = "Jonauskas"},
                };

            return Ok(tasks);
        }

    }
}