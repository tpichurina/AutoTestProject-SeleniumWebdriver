using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace AutotestTestProject
{
    [TestFixture]
    public class MenuTests : TestBase
    {
        [Test]
        public void MenuTest()
        {
            OpenLoginPage();
            LoginAsAdmin();

            IList<IWebElement> menuPoints = driver.FindElements(By.CssSelector("#box-apps-menu > li"));

            for (int i = 0; i < menuPoints.Count; i++)
            {
                IWebElement point = driver.FindElements(By.CssSelector("#box-apps-menu > li"))[i];
                point.Click();
                point = driver.FindElements(By.CssSelector("#box-apps-menu > li"))[i];

                IsElementsPresent("h1");

                for (int y = 1; y < point.FindElements(By.CssSelector("li")).Count; y++)
                {
                    point.FindElements(By.CssSelector("li"))[y].Click();
                    IsElementsPresent("h1");
                    point = driver.FindElements(By.CssSelector("#box-apps-menu > li"))[i];
                }
            }
        }
    }
}
