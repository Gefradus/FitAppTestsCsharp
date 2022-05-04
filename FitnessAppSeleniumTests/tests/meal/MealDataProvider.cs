using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.model.enums;

namespace FitnessAppSeleniumTests.tests.meal
{
    public class MealDataProvider
    {
        private static readonly Product product = ProductDataProvider.Product();

        public static Meal Meal()
        {
            return new Meal()
            {
                Product = product,
                Quantity = "100",
                MealOfTheDay = MealOfTheDay.BREAKFAST
            };
        }

        public static Meal EditedMeal()
        {
            return new Meal()
            {
                Product = product,
                Quantity = "200",
                MealOfTheDay = MealOfTheDay.BREAKFAST
            };
        }
    }
}
