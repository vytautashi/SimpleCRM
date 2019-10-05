using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sms.Api.Models;
using Sms.Api.Services;
using Sms.Api;

namespace Sms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {

        // GET api/sms
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/sms
        [HttpPost]
        public void Post([FromBody] SmsMessage smsMessage)
        {
            Program._smsService.SendSMS(smsMessage.PhoneNumber, smsMessage.SmsText);
        }

    }
}
