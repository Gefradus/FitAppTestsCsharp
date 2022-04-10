using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;

namespace FitnessAppSeleniumTests.tests
{
    public class ProductDataProvider
    {
        public static Product Product()
        {
            return new Product()
            {
                Name = StringUtils.RandomEntityName(),
                Kcal = "200",
                Proteins = "2",
                Carbohydrates = "48",
                Fats = "0",
                VitaminA = "10",
                VitaminB1 = "10",
                VitaminB2 = "10",
                VitaminB5 = "10",
                VitaminB6 = "10",
                VitaminB12 = "10",
                VitaminC = "10",
                VitaminD = "10",
                VitaminE = "10",
                VitaminK = "10",
                VitaminPP = "10",
                Biotin = "10",
                FolicAcid = "10",
                Copper = "10",
                Calcium = "10",
                Iodine = "10",
                Iron = "10",
                Magnesium = "10",
                Phosphorus = "10",
                Potassium = "10",
                Selenium = "10",
                Sodium = "10",
                Zinc = "10"
            };
            
        }
    }
}
