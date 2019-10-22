using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;

namespace SimpleCRM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTaskController : ControllerBase
    {
        private IDailyTaskService _dailyTaskService;

        public DailyTaskController(IDailyTaskService dailyTaskService)
        {
            _dailyTaskService = dailyTaskService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dailyTaskService.GetDailyTaskListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _dailyTaskService.GetDailyTaskAsync(id));
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByEmployee(int id)
        {
            return Ok(await _dailyTaskService.GetListByEmployeeIdAsync(id));
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMeTasks()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int id = Int32.Parse(identity.FindFirst("sub").Value);

            return Ok(await _dailyTaskService.GetListByEmployeeIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(DailyTaskViewModel dailyTask)
        {
            await _dailyTaskService.AddDailyTaskAsync(dailyTask);

            return Ok(await _dailyTaskService.GetDailyTaskListAsync());
        }

        [Route("[action]/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(int id, DailyTaskViewModel dailyTask)
        {
            await _dailyTaskService.UpdateStatusDailyTaskAsync(id, dailyTask);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DailyTaskViewModel dailyTask)
        {
            await _dailyTaskService.UpdateDailyTaskAsync(id, dailyTask);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dailyTaskService.DeleteDailyTaskAsync(id);

            return NoContent();
        }
    }
}