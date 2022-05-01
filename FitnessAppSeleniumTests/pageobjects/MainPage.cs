using FitnessAppSeleniumTests.framework.config;
using FitnessAppSeleniumTests.pageobjects.admin;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class MainPage : BaseFitAppPage
    {
        private const string BUTTON_PANEL = "buttonPanel";
        private const string ADMIN = "adminBtn";
        private const string MEASUREMENT = "a[href='/Measurements']";

        public ProductPage GetProducts()
        {
            Click(By.ClassName(BUTTON_PANEL));
            return new ProductPage();
        }

        public MeasurementPage GetMeasurements()
        {
            Click(By.CssSelector(MEASUREMENT));
            return new MeasurementPage();   
        }

        public AdminPage GetAdmin()
        {
            Click(By.Id(ADMIN));
            return new AdminPage();
        }
    }
}
