using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.admin
{
    public class AdminProductsPage : BasePage
    {
        private const string SEARCH = "search";
        private const string EDIT_PRODUCT = "editProduct";
        private const string DELETE_PRODUCT = "deleteProduct";
        private const string CONFIRM_DELETION = "usun";

        private void FindProduct(Product product)
        {
            FillField(By.Id(SEARCH), product.Name);
            Submit(By.Id(SEARCH));
        }

        public ManageProductPage EditProduct(Product product)
        {
            FindProduct(product);
            Click(By.ClassName(EDIT_PRODUCT));
            return new ManageProductPage();
        }

        public void DeleteProduct(Product product)
        {
            FindProduct(product);
            Click(By.ClassName(DELETE_PRODUCT));
            JavaScriptClick(By.Id(CONFIRM_DELETION));
        }
    }
}
