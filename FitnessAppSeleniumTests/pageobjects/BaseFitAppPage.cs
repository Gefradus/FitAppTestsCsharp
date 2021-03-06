using FitnessAppSeleniumTests.framework.config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class BaseFitAppPage
    {
        public BaseFitAppPage() {
        }

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

        public void WaitForPageLoaded()
        {
            var wait = new WebDriverWait(Config.GetDriver(), TimeSpan.FromSeconds(5));
            wait.Until(ContainsAtrribute(By.TagName("body"), "class", "loaded"));
            Thread.Sleep(250);
        }

        public void WaitForElementToBeClickable(IWebElement element)
        {
            var wait = new WebDriverWait(Config.GetDriver(), TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForElementFoundByToBeClickable(By by)
        {
            var wait = new WebDriverWait(Config.GetDriver(), TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static Func<IWebDriver, string> ContainsAtrribute(By locator, string attribute, string notValue)
        {
            return (driver) => {
                try
                {
                    var value = driver.FindElement(locator).GetAttribute(attribute);
                    return value.Contains(notValue) ? value : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
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
            return Config.GetDriver().FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Config.GetDriver().FindElements(by);
        }

        public void JavaScriptClick(By by)
        {
            JavaScriptClick(FindElement(by));
        }

        public void ClickCheckbox(By checkboxBy, bool value)
        {
            ClickCheckbox(FindElement(checkboxBy), value);
        }

        public void ClickCheckbox(IWebElement checkbox, bool value)
        {
            if (checkbox.Selected != value)
            {
                JavaScriptClick(checkbox);
            }
        }

        public string FindElementAndGetValue(By by)
        {
            return Config.GetDriver().FindElement(by).GetAttribute("value");
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor) Config.GetDriver();
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
