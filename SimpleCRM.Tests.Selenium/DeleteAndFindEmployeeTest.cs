using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SimpleCRM.Tests.Selenium
{
    [TestClass]
    public class DeleteAndFindEmployeeTest
    {
        IWebDriver driver;
        const string HOST_URL = "http://localhost:5001/";
        const string GECKO_DRIVER_PATH = "C:\\Program Files (x86)\\Mozilla Firefox";
        const string BROWSER_PATH = "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe";

        string deletedEmployeeUrl;

        [TestInitialize]
        public void TestInit()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = BROWSER_PATH;
            driver = new FirefoxDriver(GECKO_DRIVER_PATH, options);
        }

        [TestMethod]
        public void AddEmployeeMain()
        {
            HomePageLogin();
            IdentityServer4Login();
            GotoEmployeeList();
            GotoLastEmployee();
            GotoEmployeeList();
            DeleteLastEmployee();
            GotoDeletedEmployee();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Close();
        }



        private void HomePageLogin()
        {
            driver.Navigate().GoToUrl(HOST_URL);
            try
            {
                IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
                loginButton.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed HomePageLogin()");
            }
        }

        private void IdentityServer4Login()
        {
            try
            {
                IWebElement username = driver.FindElement(By.Id("Username"));
                IWebElement password = driver.FindElement(By.Id("Password"));
                username.SendKeys("vytautas");
                Thread.Sleep(100);
                password.SendKeys("vytautas");
                Thread.Sleep(100);

                IWebElement loginButton = driver.FindElement(By.XPath("//button[@name='button' and @value='login']"));
                loginButton.Click();

                IWebElement allowButton = driver.FindElement(By.XPath("//button[@name='button' and @value='yes']"));
                allowButton.Click();
                Thread.Sleep(100);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed IdentityServer4Login()");
            }

        }

        private void GotoEmployeeList()
        {
            try
            {
                IWebElement employeeListAhref = driver.FindElement(By.LinkText("Employee List"));
                employeeListAhref.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GotoEmployeeList()");
            }
        }

        private void GotoLastEmployee()
        {
            try
            {
                ReadOnlyCollection<IWebElement> employeeList = driver.FindElements(By.XPath("//a[contains(@href,'/employee/')]"));
                employeeList[employeeList.Count-1].Click();

                IWebElement email = driver.FindElement(By.XPath("//app-employee-viewpage"));

            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GotoLastEmployee()");
            }
        }

        private void DeleteLastEmployee()
        {
            try
            {
                ReadOnlyCollection<IWebElement> employeeList = driver.FindElements(By.XPath("//a[contains(@href,'/employee/')]"));
                deletedEmployeeUrl = employeeList[employeeList.Count - 1].GetAttribute("href");

                ReadOnlyCollection<IWebElement> employeeList2 = driver.FindElements(By.LinkText("delete"));
                employeeList2[employeeList2.Count - 1].Click();

                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();

                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed DeleteLastEmployee()");
            }
        }

        private void GotoDeletedEmployee()
        {
            try
            {
                driver.Navigate().GoToUrl(deletedEmployeeUrl);
                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-warning']"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GotoDeletedEmployee()");
            }
        }
    }
}
