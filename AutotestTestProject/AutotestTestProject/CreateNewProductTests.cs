using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AutotestTestProject
{
    [TestFixture]
    public class CreateNewProductTests : TestBase
    {
        [Test]
        public void CreateNewProductTest()
        {
            OpenLoginPage();
            LoginAsAdmin();
            OpenCatalogPage();
            Random random = new Random();
            ClickAddNewProduct();
            int randon = random.Next(55);
            string expectedName = FillInGeneralTab(random);
            GoToInformationTab();
            FillInInformationTab();
            GoToPricesTab();
            FillInPricesTab();
            // Click Save
            driver.FindElement(By.Name("save")).Click();
            Thread.Sleep(2000);
            //Compare added product name
            driver.FindElement(By.PartialLinkText(expectedName));
        }

        private void FillInPricesTab()
        {
            driver.FindElement(By.Name("purchase_price")).SendKeys(Keys.Control + "a" + Keys.Delete);
            driver.FindElement(By.Name("purchase_price")).SendKeys("100");
            SelectElement currency = new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code")));
            currency.SelectByText("US Dollars");
            driver.FindElement(By.Name("prices[USD]")).SendKeys("25");
        }

        private void GoToPricesTab()
        {
            driver.FindElement(By.CssSelector("[href *= tab-prices]")).Click();
        }

        private void FillInInformationTab()
        {
            SelectElement manufacturer = new SelectElement(driver.FindElement(By.CssSelector("[name = manufacturer_id]")));
            manufacturer.SelectByText("ACME Corp.");
            driver.FindElement(By.CssSelector("input[name=keywords]")).SendKeys("keyword");
            driver.FindElement(By.CssSelector("input[name*=short_description]")).SendKeys("short");
            driver.FindElement(By.CssSelector(".trumbowyg-editor")).SendKeys("description");
            driver.FindElement(By.CssSelector("input[name*=head_title]")).SendKeys("title");
            driver.FindElement(By.CssSelector("input[name*=meta_description]")).SendKeys("test");
        }

        private void GoToInformationTab()
        {
            driver.FindElement(By.CssSelector("[href *= tab-information]")).Click();
        }

        private void ClickAddNewProduct()
        {
            driver.FindElement(By.CssSelector("[href *= edit_product]")).Click();
        }

        private string FillInGeneralTab(Random random)
        {
            IWebElement name = driver.FindElement(By.CssSelector("input[name*=name]"));
            name.SendKeys("test" + random);
            string expectedName = name.GetAttribute("textContent");
            driver.FindElement(By.CssSelector("input[name*=code]")).SendKeys("code" + random);
            driver.FindElement(By.CssSelector("input[data-name='Rubber Ducks']")).Click();
            driver.FindElement(By.CssSelector("input[type=checkbox][value='1-3']")).Click();
            SelectElement category = new SelectElement(driver.FindElement(By.CssSelector("[name = default_category_id]")));
            category.SelectByText("Rubber Ducks");
            driver.FindElement(By.CssSelector("input[name*=code]")).SendKeys("code" + random);
            IWebElement uploadFile = driver.FindElement(By.CssSelector("input[type = file]"));
            uploadFile.SendKeys(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\image\blackDuck.png");
            driver.FindElement(By.CssSelector("[name=date_valid_from]")).SendKeys("30/10/2021");
            driver.FindElement(By.CssSelector("[name=date_valid_to]")).SendKeys("30/10/2020");
            return expectedName;
        }
    }
}
