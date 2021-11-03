using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AutotestTestProject
{
    [TestFixture]
    public class WindowsTests : TestBase
    {
        [Test]
        public void LinkTest()
        {
            OpenLoginPage();
            LoginAsAdmin();
            OpenCountriesPage();

            driver.FindElement(By.CssSelector("td:nth-child(5) > a")).Click();

            var linksList = driver.FindElements(By.CssSelector("#content td a[href^=http]"));

            foreach (var windowlink in linksList)
            {
                string startWindow = driver.CurrentWindowHandle;
                IReadOnlyCollection<string> oldWindows = driver.WindowHandles;

                windowlink.Click();

                string newWindow = wait.Until(ThereIsWindowOtherThan(oldWindows));

                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(startWindow);
            }
        }

        public Func<IWebDriver, String> ThereIsWindowOtherThan(IReadOnlyCollection<String> oldWindows)
        {
            return (wd) =>
            {
                var currentWindow = wd.WindowHandles;
                return currentWindow.Except(oldWindows).FirstOrDefault();
            };
        }
    }
}
