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
    public class AddEmployeeTest
    {
        IWebDriver driver;
        const string HOST_URL           = "http://localhost:5001/";
        const string GECKO_DRIVER_PATH  = "C:\\Program Files (x86)\\Mozilla Firefox";
        const string BROWSER_PATH       = "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe";

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
            GotoEmployeeAddForm();
            AddEmployee_Fail();
            AddEmployee_Success();
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

        private void GotoEmployeeAddForm()
        {
            try
            {
                IWebElement employeeListAhref = driver.FindElement(By.LinkText("Employee List"));
                employeeListAhref.Click();

                IWebElement addEmployeeButton = driver.FindElement(By.Id("addEmployeeButton"));
                if (!addEmployeeButton.Displayed)
                {
                    Assert.Fail("Failed GotoEmployeeAddForm() Add new employee Button invisible");
                }
                addEmployeeButton.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GotoEmployeeAddForm()");
            }
        }

        private void AddEmployee_Fail()
        {
            try
            {
                IWebElement submitButton = driver.FindElement(By.Id("submitButton"));
                submitButton.Click();

                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed AddEmployee_Fail()");
            }
        }

        private void AddEmployee_Success() {
            try
            {
                IWebElement fullname = driver.FindElement(By.XPath("//input[@placeholder='Full Name']"));
                IWebElement address  = driver.FindElement(By.XPath("//input[@placeholder='Address']"));
                IWebElement phone    = driver.FindElement(By.XPath("//input[@placeholder='Phone']"));
                IWebElement email    = driver.FindElement(By.XPath("//input[@placeholder='Email']"));
                fullname.SendKeys("Selenium Test passed: "+ DateTime.Now);
                Thread.Sleep(100);
                address.SendKeys("Klaipeda kazkur 33");
                Thread.Sleep(100);
                phone.SendKeys("865423523");
                Thread.Sleep(100);
                email.SendKeys("selenium_test@yahoo.com");
                Thread.Sleep(100);

                IWebElement roleSelectList = driver.FindElement(By.Id("roleSelectList"));
                var selectElement = new SelectElement(roleSelectList);
                selectElement.SelectByIndex(1);

                IWebElement submitButton = driver.FindElement(By.Id("submitButton"));
                submitButton.Click();
                Thread.Sleep(100);

                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed AddEmployee_Success()");
            }
        }

    }
}
