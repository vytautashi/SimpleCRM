using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCRM.App.Validators;
using SimpleCRM.Data.Models;

namespace Tests.SimpleCRM.App
{
    [TestClass]
    public class EmployeeValidatorTests
    {
        [TestMethod]
        public void IsValid_EmployeeValidation_True()
        {
            Employee[] employees = {
                new Employee{
                    FullName = "antanas",
                    RoleId = 1,
                },
                new Employee{
                    FullName = "antanas",
                    Address = "asffa",
                    RoleId = 1,
                },
                new Employee{
                    FullName = "antanas",
                    Address = "asffa",
                    Email = "w@wwwww",
                    RoleId = 1,
                },
                new Employee{
                    FullName = "antanas",
                    Address = "asffa",
                    Email = "w@wwwww",
                    Phone = "342325",
                    RoleId = 1,
                },
            };

            for (int i = 0; i < employees.Length; i++)
            {
                bool result = EmployeeValidator.isValid(employees[i]);
                Assert.IsTrue(result, "Failed item array position: " + i);
            }

        }
        [TestMethod]
        public void IsValid_EmployeeValidation_False()
        {
            Employee[] employees = {
                new Employee{
                    FullName = "an",
                    RoleId = 1,
                },
                new Employee{
                    FullName = "antanas",
                    Address = "fa",
                    RoleId = 1,
                },
                new Employee{
                    FullName = "antanas",
                    Address = "fa",
                    Email = "wwwwww",
                    RoleId = 1,
                },
                new Employee{
                    FullName = "antanas",
                    Address = "asffa",
                    Email = "w@wwwww",
                    Phone = "gdfgdf",
                    RoleId = 1,
                },
            };

            for (int i = 0; i < employees.Length; i++)
            {
                bool result = EmployeeValidator.isValid(employees[i]);
                Assert.IsFalse(result, "Failed item array position: " + i);
            }
        }
    }
}
