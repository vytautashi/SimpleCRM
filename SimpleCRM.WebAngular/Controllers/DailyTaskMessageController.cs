using System;
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
    public class DailyTaskMessageController : ControllerBase
    {
        private IDailyTaskMessageService _dailyTaskMessageService;

        public DailyTaskMessageController(IDailyTaskMessageService dailyTaskMessageService)
        {
            _dailyTaskMessageService = dailyTaskMessageService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dailyTaskMessageService.GetListAsync());
        }
    }
}