using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutotestTestProject
{
    [TestFixture]
    public class RegistrationTests : TestBase
    {

        [Test]
        public void RegistrationTest()
        {

            OpenCreateAccountPage(); ;
            Random random = new Random();
            String email = "test" + (random.Next(100)) + "@mail.com";
            String password = "test";

            driver.FindElement(By.Name("firstname")).SendKeys("FName");
            driver.FindElement(By.Name("lastname")).SendKeys("LName");
            driver.FindElement(By.Name("address1")).SendKeys("Address");
            driver.FindElement(By.Name("postcode")).SendKeys("12345");
            driver.FindElement(By.Name("city")).SendKeys("City");
            SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("[name = country_code]")));
            select1.SelectByText("United States");
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("phone")).SendKeys("+380501234567");
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("confirmed_password")).SendKeys(password);

            driver.FindElement(By.Name("create_account")).Click();

            driver.FindElement(By.CssSelector("[href *= logout]")).Click();

            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.CssSelector("[href *= logout]")).Click();


        }
    }
}
