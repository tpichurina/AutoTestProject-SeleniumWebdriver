using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutotestTestProject
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            //driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

        protected void LoginAsAdmin()
        {
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
        }

        protected void OpenLoginPage()
        {
            driver.Url = "http://localhost/litecart/admin";
        }

        protected void Timeout(int s = 5)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(s);
        }

        protected void IsElementsPresent(string selector)
        {
            driver.FindElement(By.CssSelector(selector));
        }

        protected void OpenMianPage()
        {
            driver.Url = "http://localhost/litecart/en/";
        }

        protected void OpenCountriesPage()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
        }
        protected void OpenZonesPage()
        {
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
        }
        protected void OpenCreateAccountPage()
        {
            driver.Url = "http://localhost/litecart/en/create_account";
        }
    }
}
