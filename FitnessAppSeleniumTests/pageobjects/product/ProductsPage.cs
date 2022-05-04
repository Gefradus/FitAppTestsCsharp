using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects.meal;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class ProductsPage : BaseFitAppPage
    {
        private const string ADD_PRODUCT = "addProduct";
        private const string BACK_TO_MAIN_PAGE = "//a[./img[@id='logoPink']]";
        private const string SHOW_MODAL_ADD_MEAL_BTN = "showModalAddMealBtn";
        private const string TABLE_ROW = "tableRow";
        private const string SEARCH_INPUT = "searchInput";

        public ManageProductPage AddProduct()
        {
            Click(By.Id(ADD_PRODUCT));
            return new ManageProductPage();
        }

        private void FindProduct(Product product)
        {
            By searchInput = By.Id(SEARCH_INPUT);
            FillField(searchInput, product.Name);
            Submit(searchInput);
        }

        public MealPage FindProductAndAddMeal(Product product)
        {
            FindProduct(product);
            Click(By.ClassName(SHOW_MODAL_ADD_MEAL_BTN));
            return new MealPage();
        }

        public bool ProductExists(Product product)
        {
            FindProduct(product);
            int count = FindElements(By.ClassName(TABLE_ROW)).Count;
            return count > 0;
        }

        public MainPage GoBackToMainPage()
        {
            JavaScriptClick(By.XPath(BACK_TO_MAIN_PAGE));
            return new MainPage();
        }
    }
}
