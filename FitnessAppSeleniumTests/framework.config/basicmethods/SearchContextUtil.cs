using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.framework.config.basicmethods
{
    public class SearchContextUtil
    {
        private static readonly IWebDriver driver = Config.GetDriver();

        public static IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }
    }
}
