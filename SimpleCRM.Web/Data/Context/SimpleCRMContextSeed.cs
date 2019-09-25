using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SimpleCRM.Data.Models;

namespace SimpleCRM.Data.Context
{
    public class SimpleCRMContextSeed
    {
        public static void Initialize(SimpleCRMContext context)
        {
            context.Database.EnsureCreated();
            if (DbEmpty(context))
            {
                SeedDb(context);
            }
        }
        private static bool DbEmpty(SimpleCRMContext context)
        {
            return !context.Employees.Any() 
                && !context.DailyTasks.Any();
        }
        private static void SeedDb(SimpleCRMContext context)
        {
            AddEmployees(context);
            AddDailyTasks(context);
        }
        private static void AddEmployees(SimpleCRMContext context)
        {
            var employees = new Employee[]{
                new Employee{EmployeeId = 1, FirstName = "Antanas", LastName = "Antanauskas", Connected = true},
                new Employee{EmployeeId = 2, FirstName = "Onute", LastName = "Antanauskiene", Connected = true},
                new Employee{EmployeeId = 3, FirstName = "Jonas",LastName = "Jonauskas", Connected = false},
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
        private static void AddDailyTasks(SimpleCRMContext context)
        {
            var tasks = new DailyTask[]{
                new DailyTask{Title = "Sky web programming", Description = "", Employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 1)},
                new DailyTask{Title = "Sky web testing", Description = "", Employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 1)},
                new DailyTask{Title = "Sky web UI design", Description = "", Employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 3)},
                };

            context.DailyTasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
