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

        private DailyTaskDto ToDailyTaskDto(DailyTask task)
        {
            DailyTaskDto dailyTaskDto = new DailyTaskDto
            {
                DailyTaskId = task.DailyTaskId,
                Title = task.Title,
                Description = task.Description,
            };
            if (task.Employee != null)
            {
                dailyTaskDto.EmployeeId = task.Employee.EmployeeId;
                dailyTaskDto.EmployeeFirstName = task.Employee.FirstName;
                dailyTaskDto.EmployeeLastName = task.Employee.LastName;
            }
            return dailyTaskDto;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dailyTasks = await _context.DailyTasks.Include(e => e.Employee).ToListAsync();
            var tasksDto = new List<DailyTaskDto>();

            foreach (var task in dailyTasks)
            {
                tasksDto.Add(ToDailyTaskDto(task));
            }

            return Ok(tasksDto);
        }

    }
}