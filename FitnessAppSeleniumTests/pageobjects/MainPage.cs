using FitnessAppSeleniumTests.framework.config;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class MainPage : BasePage
    {
        private const string BUTTON_PANEL = "buttonPanel";

        public ProductPage GetProducts()
        {
            Click(By.ClassName(BUTTON_PANEL));
            return new ProductPage();
        }

    }
}
