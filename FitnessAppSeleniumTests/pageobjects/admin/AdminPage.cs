using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.admin
{
    public class AdminPage : BaseFitAppPage
    {
        private const string PRODUCTS = "a[href='/Admin/AdminProduct']";
        private const string TRAININGS = "a[href='/Admin/AdminTraining']";

        public AdminProductsPage GetProducts()
        {
            WaitForPageLoaded();
            Click(By.CssSelector(PRODUCTS));
            return new AdminProductsPage();
        }

       public AdminTrainingsPage GetTrainings()
        {
            WaitForPageLoaded();
            Click(By.CssSelector(TRAININGS));
            return new AdminTrainingsPage();
        }
    }
}
