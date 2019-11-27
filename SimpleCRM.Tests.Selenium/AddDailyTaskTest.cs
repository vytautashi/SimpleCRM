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
    public class AddDailyTaskTest
    {
        IWebDriver driver;
        const string HOST_URL = "http://localhost:5001/";
        const string GECKO_DRIVER_PATH = "C:\\Program Files (x86)\\Mozilla Firefox";
        const string BROWSER_PATH = "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe";

        [TestInitialize]
        public void TestInit()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = BROWSER_PATH;
            driver = new FirefoxDriver(GECKO_DRIVER_PATH, options);
        }

        [TestMethod]
        public void AddDailyTaskMain()
        {
            HomePageLogin();
            IdentityServer4Login();
            GotoDailyTaskAddForm();
            AddDailyTask_Fail();
            AddDailyTask_Success();
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

        private void GotoDailyTaskAddForm()
        {
            try
            {
                IWebElement taskListAhref = driver.FindElement(By.LinkText("Task List"));
                taskListAhref.Click();

                IWebElement addDailyTaskButton = driver.FindElement(By.Id("addDailyTaskButton"));
                if (!addDailyTaskButton.Displayed)
                {
                    Assert.Fail("Failed GotoDailyTaskAddForm() Add new task Button invisible");
                }
                addDailyTaskButton.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GotoDailyTaskAddForm()");
            }
        }

        private void AddDailyTask_Fail()
        {
            try
            {
                IWebElement submitButton = driver.FindElement(By.Id("submitButton"));
                submitButton.Click();

                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed AddDailyTask_Fail()");
            }
        }

        private void AddDailyTask_Success()
        {
            try
            {
                IWebElement title = driver.FindElement(By.XPath("//input[@placeholder='Title']"));
                IWebElement description = driver.FindElement(By.XPath("//input[@placeholder='Description']"));
                IWebElement priority = driver.FindElement(By.XPath("//input[@placeholder='Priority']"));
                IWebElement status = driver.FindElement(By.XPath("//input[@placeholder='Status']"));
                title.SendKeys("Selenium Test passed: " + DateTime.Now);
                Thread.Sleep(100);
                description.SendKeys("Testing");
                Thread.Sleep(100);
                priority.SendKeys((new Random().Next(5)+1).ToString());
                Thread.Sleep(100);
                status.SendKeys("2");
                Thread.Sleep(100);

                IWebElement employeeSelectList = driver.FindElement(By.Id("employeeSelectList"));
                var selectElement = new SelectElement(employeeSelectList);
                selectElement.SelectByIndex(1);

                IWebElement submitButton = driver.FindElement(By.Id("submitButton"));
                submitButton.Click();
                Thread.Sleep(100);

                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-success']"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed AddDailyTask_Success()");
            }
        }

    }
}
