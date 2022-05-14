using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FitnessAppSeleniumTests.framework.config
{
    public class Config
    {
        private const string DRIVER_DIRECTORY = @"C:\Users\ComPP\Desktop\MAGISTERKA\chromdriver\";
        private const string ALLOW_INSECURE_LOCALHOST = "--allow-insecure-localhost";

        private static IWebDriver Driver;

        public static IWebDriver GetDriver()
        {
            if(Driver == null)
                InitWebDriver();
            return Driver;
        }

        public static void InitWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument(ALLOW_INSECURE_LOCALHOST);
            Driver = new ChromeDriver(DRIVER_DIRECTORY, options);
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
