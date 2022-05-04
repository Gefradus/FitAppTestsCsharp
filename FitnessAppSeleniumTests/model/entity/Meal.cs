using FitnessAppSeleniumTests.model.enums;

namespace FitnessAppSeleniumTests.model.entity
{
    public class Meal
    {
        public Product Product { get; set; }
        public string Quantity { get; set; }
        public MealOfTheDay MealOfTheDay { get; set; }
    }
}
