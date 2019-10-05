using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sms.Api.Services;

namespace Sms.Api
{
    public class Program
    {
        public static SmsService _smsService;

        public static void Main(string[] args)
        {
            InitSmsService();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static void InitSmsService()
        {
            ConsoleLogger.WriteLine("Enter Port:");
            string port = Console.ReadLine();

            _smsService = new SmsService(port);
            _smsService.SendSMS("861711354", "test");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
