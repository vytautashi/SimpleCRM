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
                && !context.DailyTasks.Any()
                && !context.Roles.Any()
                && !context.Customers.Any();
        }
        private static void SeedDb(SimpleCRMContext context)
        {
            AddRoles(context);
            AddEmployees(context);
            AddDailyTasks(context);
            AddCustomers(context);
        }

        private static void AddCustomers(SimpleCRMContext context)
        {
            var customers = new Customer[]{
                new Customer
                {
                    Id = 1,
                    Email = "all.ignas80@yahoo.com",
                    FullName = "Ignas D.",
                    Phone = "862345222",
                    LastContacted = DateTime.Today,
                    ActiveAds = 7,
                    OpenIssue = 1,
                },
                new Customer
                {
                    Id = 2,
                    Email = "j.jonas@gmail.com",
                    FullName = "Jonas Jonaitis",
                    Phone = "864233552",
                    LastContacted = DateTime.Now,
                    ActiveAds = 1,
                    OpenIssue = 0,
                },
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
        private static void AddRoles(SimpleCRMContext context)
        {
            var roles = new Role[]{
                new Role{Name = "Programmer"},
                new Role{Name = "Designer"},
                new Role{Name = "Lead Programmer"},
                new Role{Name = "Manager"},
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
        private static void AddEmployees(SimpleCRMContext context)
        {
            var employees = new Employee[]{
                new Employee{FullName = "Antanas Antanauskas"
                , Address = "Aukstaiciu 22, Klaipeda Lithuania"
                , Phone = "86342342"
                , Email = "--1ioi23--@gmail.com"
                , Online = true
                , Role = context.Roles.FirstOrDefault(e => e.Id == 1)
                },

                new Employee{FullName = "Onute Antanauskiene"
                , Address = "Aukstaiciu 22, Klaipeda Lithuania"
                , Phone = "863234234"
                , Email = "dfvs3423vdd@yahoo.com"
                , Online = true
                , Role = context.Roles.FirstOrDefault(e => e.Id == 1)
                },

                new Employee{FullName = "Jonas Jonauskas"
                , Address = "Onutes 123-4, Vilnius Lithuania"
                , Phone = "8624235234"
                , Email = "nnnnerwr323r@yahoo.com"
                , Online = false
                , Role = context.Roles.FirstOrDefault(e => e.Id == 2)
                },

                new Employee{FullName = "Vytautas"
                , Address = "Klaipeda Lithuania"
                , Phone = "**********"
                , Email = "********@yahoo.com"
                , Online = true
                , Role = context.Roles.FirstOrDefault(e => e.Id == 1)
                },

                new Employee{FullName = "Petras N"
                , Address = "Vilnius Lithuania"
                , Phone = "862352643"
                , Email = "tik@gmail.com"
                , Online = false
                , Role = context.Roles.FirstOrDefault(e => e.Id == 4)
                },
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
        private static void AddDailyTasks(SimpleCRMContext context)
        {
            var tasks = new DailyTask[]{
                new DailyTask{Title = "[Sky web] create user verification module"
                , Description = ""
                , Status = DailyTask.DailyTaskStatus.Ongoing
                , Priority = DailyTask.DailyTaskPriority.Low
                , Employee = context.Employees.FirstOrDefault(e => e.Id == 1)
                },

                new DailyTask{Title = "[Sky web] write unit test for customer module"
                , Description = ""
                , Status = DailyTask.DailyTaskStatus.Ongoing
                , Priority = DailyTask.DailyTaskPriority.Low
                , Employee = context.Employees.FirstOrDefault(e => e.Id == 1)
                },

                new DailyTask{Title = "[Sky web] UI design login screen"
                , Description = ""
                , Status = DailyTask.DailyTaskStatus.Ongoing
                , Priority = DailyTask.DailyTaskPriority.Lowest
                , Employee = context.Employees.FirstOrDefault(e => e.Id == 3)
                },

                new DailyTask{Title = "create Employee add form"
                , Description = "no info"
                , Status = DailyTask.DailyTaskStatus.Ongoing
                , Priority = DailyTask.DailyTaskPriority.Normal
                , Employee = context.Employees.FirstOrDefault(e => e.Id == 4)
                },

                new DailyTask{Title = "extend DailyTask model"
                , Description = ""
                , Status = DailyTask.DailyTaskStatus.Completed
                , Priority = DailyTask.DailyTaskPriority.Normal
                , Employee = context.Employees.FirstOrDefault(e => e.Id == 4)
                },

                new DailyTask{Title = "Refactor Repositories, create generetic class"
                , Description = ""
                , Status = DailyTask.DailyTaskStatus.Frozen
                , Priority = DailyTask.DailyTaskPriority.Important
                , Employee = context.Employees.FirstOrDefault(e => e.Id == 4)
                },
            };

            context.DailyTasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
