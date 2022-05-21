using FitnessAppSeleniumTests.model.enums;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.model.entity
{
    public class Diet
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public ISet<DaysOfTheWeek> DaysOfTheWeek { get; set; }
        public List<ProductOfDiet> ProductsOfDiet { get; set; }
    }
}
