﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> Post(DailyTaskViewModel dailyTask)
        {
            await _dailyTaskService.AddDailyTaskAsync(dailyTask);

            return Ok(await _dailyTaskService.GetDailyTaskListAsync());
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