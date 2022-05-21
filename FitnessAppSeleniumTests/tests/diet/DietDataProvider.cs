using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.model.enums;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.tests.diet
{
    public class DietDataProvider
    {
        private readonly static Product product = ProductDataProvider.Product();

        public static Diet Diet()
        {
            var productOfDiets = new List<ProductOfDiet>
            {
                new ProductOfDiet()
                {
                    Product = product,
                    Quantity = "100"
                }
            };

            var daysOfTheWeeks = new HashSet<DaysOfTheWeek>
            {
                DaysOfTheWeek.MONDAY,
                DaysOfTheWeek.FRIDAY,
                DaysOfTheWeek.SUNDAY
            };

            return new Diet()
            {
                Name = StringUtils.RandomEntityName(),
                Active = false,
                DaysOfTheWeek = daysOfTheWeeks,
                ProductsOfDiet = productOfDiets
            };
        }

        public static Diet EditedDiet()
        {
            var productOfDiets = new List<ProductOfDiet>
            {
                new ProductOfDiet()
                {
                    Product = product,
                    Quantity = "200"
                }
            };

            var daysOfTheWeeks = new HashSet<DaysOfTheWeek>
            {
                DaysOfTheWeek.TUESDAY,
                DaysOfTheWeek.FRIDAY,
                DaysOfTheWeek.SUNDAY
            };

            return new Diet()
            {
                Name = StringUtils.RandomEntityName(),
                Active = false,
                DaysOfTheWeek = daysOfTheWeeks,
                ProductsOfDiet = productOfDiets
            };
        }

    }

}
