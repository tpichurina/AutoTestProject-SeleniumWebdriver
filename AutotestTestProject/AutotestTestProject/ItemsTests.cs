using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutotestTestProject
{
    [TestFixture]
    public class StickerTests : TestBase
    {
        [Test]
        public void StickerTest()
        {
            OpenMianPage();
            IList<IWebElement> items = driver.FindElements(By.CssSelector("li.product"));

            foreach (var item in items)
            {
                Assert.IsTrue(item.FindElements(By.CssSelector("div.sticker")).Count == 1);
            }
        }
    }
}
