using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects.admin;
using FitnessAppSeleniumTests.pageobjects.diet;
using FitnessAppSeleniumTests.pageobjects.meal;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class MainPage : BaseFitAppPage
    {
        private const string BUTTON_PANEL = "buttonPanel";
        private const string ADMIN = "adminBtn";
        private const string MEASUREMENT = "a[href='/Measurements']";
        private const string TRAINING = "a[href='/Training']";
        private const string DIETS = "a[href='/DietCreator/ActiveDiets']";
        private const string PRODUCT = " .product";
        private const string HEADER = "napro";
        private const string DELETE_BUTTON = "btnUsuEdy";
        private const string CONFIRM_DELETION = "delete";
        private const char HASH = '#';
        private const char GRAM_UNIT = 'g';

        public ProductsPage GetProducts()
        {
            Click(By.ClassName(BUTTON_PANEL));
            return new ProductsPage();
        }

        public ProductsPage GetMeal(Meal meal)
        {
            IWebElement addMealBtn = FindElement(By.CssSelector("a." + meal.MealOfTheDay.Value));
            JavaScriptClick(addMealBtn);
            return new ProductsPage();
        }

        public MeasurementPage GetMeasurements()
        {
            Click(By.CssSelector(MEASUREMENT));
            return new MeasurementPage();   
        }

        public TrainingPage GetTrainings()
        {
            Click(By.CssSelector(TRAINING));
            return new TrainingPage();
        }

        public DietPage GetDiets()
        {
            Click(By.CssSelector(DIETS));
            return new DietPage();
        }

        public AdminPage GetAdmin()
        {
            Click(By.Id(ADMIN));
            return new AdminPage();
        }

        public MealPage EditMeal(Meal meal)
        {
            IWebElement mealRow = FindMeal(meal);
            mealRow.Click();
            return new MealPage();
        }


        private IWebElement FindMeal(Meal meal)
        {
            WaitForPageLoaded();
            IList<IWebElement> rows = FindElements(By.CssSelector(HASH + meal.MealOfTheDay.Value + PRODUCT));
            if (rows.Count > 0)
            {
                IWebElement row = rows[rows.Count - 1];
                string headerText = row.FindElement(By.ClassName(HEADER)).Text;
                bool containsName = headerText.Contains(meal.Product.Name);
                bool containsQuantity = headerText.Contains(meal.Quantity + GRAM_UNIT);
                if (containsName && containsQuantity)
                    return row;
            }
            throw new RowNotFoundException();
        }

        public bool MealExists(Meal meal)
        {
            try
            {
                FindMeal(meal);
                return true;
            } catch (RowNotFoundException)
            {
                return false;
            }
        } 

        public void DeleteMeal(Meal meal)
        {
            WaitForPageLoaded();
            IWebElement mealRow = FindMeal(meal);
            JavaScriptClick(mealRow.FindElement(By.ClassName(DELETE_BUTTON)));
            IWebElement confirmDeletion = FindElement(By.Id(CONFIRM_DELETION));
            WaitForElementToBeClickable(confirmDeletion);
            confirmDeletion.Click();
            WaitForPageLoaded();
        }
    }
}
