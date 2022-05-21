using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.framework.config.basicmethods
{
    public class SearchContextUtil
    {
        public static IWebElement FindElement(By by)
        {
            return Config.GetDriver().FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Config.GetDriver().FindElements(by);
        }
    }
}
