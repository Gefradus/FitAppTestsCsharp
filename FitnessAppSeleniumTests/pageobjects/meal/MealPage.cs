using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.meal
{
    public class MealPage : BaseFitAppPage
    {
        private const string EDIT_MEAL = "editMeal";
        private const string ADD_MEAL = "addMeal";
        private const string GRAMMAGE = "grammage";

        public void FillForm(Meal meal)
        {
            FillField(By.Id(GRAMMAGE), meal.Quantity);
        }

        public MainPage Submit(bool edit)
        {
            IWebElement button = FindElement(By.Id(edit ? EDIT_MEAL : ADD_MEAL));
            button.Click();
            return new MainPage();
        }
    }
}
