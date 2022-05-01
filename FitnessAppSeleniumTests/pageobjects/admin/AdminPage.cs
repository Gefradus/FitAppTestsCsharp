using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.admin
{
    public class AdminPage : BaseFitAppPage
    {
        private const string PRODUCTS = "a[href='/Admin/AdminProduct']";

        public AdminProductsPage GetProducts()
        {
            Click(By.CssSelector(PRODUCTS));
            return new AdminProductsPage();
        }

       
    }
}
