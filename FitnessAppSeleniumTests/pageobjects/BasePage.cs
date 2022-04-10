using FitnessAppSeleniumTests.framework.config;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class BasePage
    {
        readonly static IWebDriver driver = Config.GetDriver();

        public void FillField(By by, string data)
        {
            if(data != null)
            {
                IWebElement field = FindElement(by);
                field.Click();
                field.Clear();
                field.SendKeys(data);
            }
        }

        public void Click(By by)
        {
            FindElement(by).Click();
        }
        public void Submit(By by)
        {
            FindElement(by).Submit();
        }

        public static IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public static IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        public void JavaScriptClick(By by)
        {
            JavaScriptClick(FindElement(by));
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor) driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
