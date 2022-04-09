using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FitnessAppSeleniumTests
{
    public class BaseTest
    {
        IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup() 
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test1() 
        {
            Driver.Navigate().GoToUrl("https://localhost:44315/");
            Driver.Manage().Window.Maximize();
            IWebElement logSide = Driver.FindElement(By.Id("logSide"));
            logSide.FindElement(By.Id("LoginOrEmail")).SendKeys("admin");
            logSide.FindElement(By.Id("Password")).SendKeys("admin");
            JavaScriptClick(logSide.FindElement(By.CssSelector("button[type='submit']")));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}