using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace AutotestTestProject
{
    [TestFixture]
    public class CartTests : TestBase
    {
        [Test]
        public void AddToCartTest()
        {
            OpenMianPage();

            for (int count = 0; count < 3; count++)
            {
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.content a.link")));
                driver.FindElement(By.CssSelector("div.content a.link")).Click();

                wait.Until(ExpectedConditions.ElementExists(By.Name("add_cart_product")));
                if (driver.FindElements(By.CssSelector("div.buy_now select")).Count != 0)
                {
                    driver.FindElement(By.CssSelector("div.buy_now select")).Click();
                    driver.FindElement(By.CssSelector("div.buy_now select option[value=Small]")).Click();
                }
                driver.FindElement(By.Name("add_cart_product")).Click();

                var now = DateTime.Now;
                wait.Until(wd => (DateTime.Now - now).TotalSeconds > 1);
                driver.FindElement(By.CssSelector("#site-menu li.general-0 a")).Click();
            }
            driver.FindElement(By.CssSelector("#cart a.link")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#order_confirmation-wrapper")));

            while (driver.FindElements(By.Name("remove_cart_item")).Count > 0)
            {
                var rowsCount = driver.FindElements(By.CssSelector("#order_confirmation-wrapper tr")).Count;
                driver.FindElement(By.Name("remove_cart_item")).Click();
                wait.Until(wd => wd.FindElements(By.CssSelector("#order_confirmation-wrapper tr")).Count != rowsCount);
            }
        }
    }
}
