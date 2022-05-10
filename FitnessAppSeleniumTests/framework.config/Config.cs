using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FitnessAppSeleniumTests.framework.config
{
    public class Config
    {
        private const string DRIVER_DIRECTORY = @"C:\Users\ComPP\Desktop\MAGISTERKA\chromdriver\";

        private static IWebDriver Driver;

        public static IWebDriver GetDriver()
        {
            if(Driver == null)
                InitWebDriver();
            return Driver;
        }

        public static void InitWebDriver()
        {
            Driver = new ChromeDriver(DRIVER_DIRECTORY);
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            Driver.Manage().Window.Maximize();        
        }

        public static void CloseDriver()
        {
            Driver.Quit();
            Driver = null;
        }
    }
    
}
