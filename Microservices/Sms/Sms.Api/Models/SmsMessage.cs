using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.Api.Models
{
    public class SmsMessage
    {
        public string PhoneNumber { get; set; }
        public string SmsText { get; set; }
    }
}
