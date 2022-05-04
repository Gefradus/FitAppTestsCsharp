using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.meal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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

        [Test]
        public void AddMeal()
        {
            Meal meal = MealDataProvider.Meal();
            AddProduct(meal);
            MealPage mealPage = productsPage.FindProductAndAddMeal(meal.Product);
            mealPage.FillForm(meal);
            mainPage = mealPage.Submit(false);
            this.meal = meal;
            Assert.True(mainPage.)
        }
    }
}
