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
    public class AddCompanyTest
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
        public void AddEmployeeMain()
        {
            HomePageLogin();
            IdentityServer4Login();
            GotoCompanyAddForm();
            GetCompanyByNameExternalResource();
            GetDetailsAndAutoFill();
            FillRemainingAndSubmitCompany();
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

        private void GotoCompanyAddForm()
        {
            try
            {
                IWebElement companyListAhref = driver.FindElement(By.LinkText("Company List"));
                companyListAhref.Click();

                IWebElement addCompanyButton = driver.FindElement(By.XPath("//button[@type='button' and text() = 'Add new']"));
                addCompanyButton.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GotoCompanyAddForm()");
            }
        }

        private void GetCompanyByNameExternalResource()
        {
            try
            {
                IWebElement name = driver.FindElement(By.XPath("//input[@placeholder='Name']"));
                name.SendKeys("soft");

                IWebElement submitButton = driver.FindElement(By.Id("findNameButton"));
                submitButton.Click();
                Thread.Sleep(100);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GetCompanyByNameExternalResource()");
            }
        }

        private void GetDetailsAndAutoFill()
        {
            try
            {
                IWebElement companyCard;
                int cardIndex;

                ReadOnlyCollection<IWebElement> companyCards = driver.FindElements(By.ClassName("card-title"));
                cardIndex = companyCards.Count >= 3 ? new Random().Next(3) : 0;

                companyCard = companyCards[cardIndex];

                IWebElement getDetailsLink = companyCard.FindElement(By.LinkText("Get details"));
                getDetailsLink.Click();
                Thread.Sleep(100);

                IWebElement autoFillForm = companyCard.FindElement(By.LinkText("Fill"));
                autoFillForm.Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed GetDetailsAndAutoFill()");
            }
        }

        private void FillRemainingAndSubmitCompany()
        {
            try
            {
                IWebElement phone = driver.FindElement(By.XPath("//input[@placeholder='Phone']"));
                phone.SendKeys("Selenium Test passed: " + DateTime.Now);

                IWebElement submitButton = driver.FindElement(By.XPath("//button[@type='button' and text() = 'Submit']"));
                submitButton.Click();
                Thread.Sleep(100);
                IWebElement alertMsg = driver.FindElement(By.XPath("//div[@class='alert alert-success']"));

            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Failed FillRemainingAndSubmitCompany()");
            }
        }
    }
}
