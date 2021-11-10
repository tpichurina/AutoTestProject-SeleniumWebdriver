using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace AutotestTestProject
{
    [TestFixture]
    public class LogsTests : TestBase
    {
        [Test]
        public void LogTest()
        {
            OpenLoginPage();
            LoginAsAdmin();
            OpenCatalogPageWithItems();

            IList<IWebElement> catalogItems = driver.FindElements(By.CssSelector("td:nth-child(3) > a"));

            for (int i = 0; i < catalogItems.Count; i++)
            {
                IWebElement item = driver.FindElements(By.CssSelector("td:nth-child(3) > a"))[i];
                item.Click();
                string name = driver.FindElement(By.CssSelector("[name = 'name[en]'")).GetAttribute("value");
                System.Console.WriteLine(name);

                IList<LogEntry> logs = driver.Manage().Logs.GetLog("browser");
                if (logs.Count > 0)
                {
                    System.Console.WriteLine("Logs List " + name + " : " + logs);
                }

                Assert.AreEqual(0, logs.Count);

                driver.Navigate().Back();
            }
        }
    }
}
