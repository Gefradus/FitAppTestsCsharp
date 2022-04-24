using FitnessAppSeleniumTests.framework.config;
using FitnessAppSeleniumTests.pageobjects.admin;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class MainPage : BasePage
    {
        private const string BUTTON_PANEL = "buttonPanel";
        private const string ADMIN = "adminBtn";

        public ProductPage GetProducts()
        {
            Click(By.ClassName(BUTTON_PANEL));
            return new ProductPage();
        }

        public AdminPage GetAdmin()
        {
            Click(By.Id(ADMIN));
            return new AdminPage();
        }
    }
}
