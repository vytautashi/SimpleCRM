using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var dailyTask = await _dailyTaskService.GetDailyTaskAsync(id);

            if (dailyTask.DailyTaskId != 0)
                return Ok(dailyTask);
            else
                return NotFound();
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(DailyTaskDto dailyTask)
        {
            bool success = await _dailyTaskService.AddDailyTaskAsync(dailyTask, getUserId());
            if (success)
                return Ok();
            else
                return BadRequest();
        }

        [Route("[action]/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(int id, DailyTaskDto dailyTask)
        {
            await _dailyTaskService.UpdateStatusDailyTaskAsync(id, dailyTask, getUserId());
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DailyTaskDto dailyTask)
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

        private int getUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return Int32.Parse(identity.FindFirst("sub").Value);
        }
    }
}