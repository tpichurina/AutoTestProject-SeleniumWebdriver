using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutotestTestProject
{
    [TestFixture]
    public class CountriesAndZonesTests : TestBase
    {

        [Test]
        public void CountriesTest()
        {
            OpenLoginPage();
            LoginAsAdmin();
            OpenCountriesPage();

            IList<IWebElement> rows = driver.FindElements(By.CssSelector("tr.row"));
            List<string> countriesList = new List<string> { };
            List<string> zoneList = new List<string> { };
            for (int i = 0; i < rows.Count; i++)
            {
                rows = driver.FindElements(By.CssSelector("tr.row"));
                IWebElement country = driver.FindElements(By.CssSelector("td:nth-child(5) > a"))[i];
                IWebElement zone = driver.FindElements(By.CssSelector("td:nth-child(6)"))[i];

                countriesList.Add(country.GetAttribute("textContent"));
                int zoneCount = Int32.Parse(zone.GetAttribute("textContent"));

                if (zoneCount > 0)
                {
                    country.Click();
                    IList<IWebElement> zones = driver.FindElements(By.CssSelector("[type = hidden][name *= name]"));
                    foreach (WebElement z in zones)
                    {
                        zoneList.Add(z.GetAttribute("value"));
                    }
                    List<string> zonesListSorted = new List<string> { };
                    foreach (string z in zoneList)
                    {
                        zonesListSorted.Add(z);
                    }
                    zonesListSorted.Sort();
                    Assert.AreEqual(zoneList, zonesListSorted);
                    zoneList.Clear();
                    zonesListSorted.Clear();

                    OpenCountriesPage();
                }
            }

            List<string> countriesListSorted = new List<string> { };
            foreach (string c in countriesList)
            {
                countriesListSorted.Add(c);
            }
            countriesListSorted.Sort();
            Assert.AreEqual(countriesList, countriesListSorted);
        }


        [Test]
        public void ZoneTest()
        {
            OpenLoginPage();
            LoginAsAdmin();
            OpenZonesPage();

            IList<IWebElement> rows = driver.FindElements(By.CssSelector("tr.row"));

            for (int i = 0; i < rows.Count; i++)
            {
                rows = driver.FindElements(By.CssSelector("tr.row"));
                IWebElement country = driver.FindElements(By.CssSelector("td:nth-child(3) > a"))[i];
                country.Click();

                IList<IWebElement> zones = driver.FindElements(By.CssSelector("[name *= zone_code] > [selected = selected]"));
                List<string> zonesList = new List<string> { };
                foreach (WebElement z in zones)
                {
                    zonesList.Add(z.GetAttribute("textContent"));
                }

                List<string> zonesListSorted = new List<string> { };
                foreach (string z in zonesList)
                {
                    zonesListSorted.Add(z);
                }
                zonesListSorted.Sort();
                Assert.AreEqual(zonesList, zonesListSorted);
                zonesList.Clear();
                zonesListSorted.Clear();

                OpenZonesPage();
            }
        }
    }
}
