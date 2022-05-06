using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.admin;
using FitnessAppSeleniumTests.pageobjects.meal;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests.meal
{
    public class MealTest : BaseFitAppTest
    {
        private Meal meal;
        private MainPage mainPage;
        private ProductsPage productsPage;

        private void AddProduct(Meal meal)
        {
            productsPage = new MainPage().GetMeal(meal);
            ManageProductPage manageProductPage = productsPage.AddProduct();
            manageProductPage.FillForm(meal.Product);
            productsPage = manageProductPage.Submit();
            Assert.True(productsPage.ProductExists(meal.Product));
        }

        [Test, Order(1)]
        public void AddMeal()
        {
            Meal meal = MealDataProvider.Meal();
            AddProduct(meal);
            MealPage mealPage = productsPage.FindProductAndAddMeal(meal.Product);
            mealPage.FillForm(meal);
            mainPage = mealPage.Submit(false);
            this.meal = meal;
            Assert.True(mainPage.MealExists(meal));
        }

        [Test, Order(2)]
        public void EditMeal()
        {
            MealPage mealPage = mainPage.EditMeal(meal);
            Meal editedMeal = MealDataProvider.EditedMeal();
            mealPage.FillForm(editedMeal);
            mainPage = mealPage.Submit(true);
            bool afterEdit = mainPage.MealExists(editedMeal);
            if (afterEdit) meal = editedMeal;
            Assert.True(afterEdit);
        }

        [Test, Order(3)]
        public void DeleteMeal()
        {
            mainPage.DeleteMeal(meal);
            Assert.False(mainPage.MealExists(meal));
        }

        [OneTimeTearDown]
        public void DeleteProduct()
        {
            AdminProductsPage adminProductsPage = mainPage.GetAdmin().GetProducts();
            adminProductsPage.DeleteProduct(meal.Product);
        }
    }
}
