using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.Services;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Repositories;

namespace SimpleCRM.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IEmpoyeeService, EmployeeService>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();

            service.AddScoped<IDailyTaskService, DailyTaskService>();
            service.AddScoped<IDailyTaskRepository, DailyTaskRepository>();

            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IRoleRepository, RoleRepository>();

            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
