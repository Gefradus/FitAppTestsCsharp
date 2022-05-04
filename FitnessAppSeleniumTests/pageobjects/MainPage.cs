using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects.admin;
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
        private const string PRODUCT = " .product";
        private const string HEADER = "napro";
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

        public AdminPage GetAdmin()
        {
            Click(By.Id(ADMIN));
            return new AdminPage();
        }

        private IWebElement FindMeal(Meal meal)
        {
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
    }
}
