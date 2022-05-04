namespace FitnessAppSeleniumTests.model.enums
{
    public class MealOfTheDay
    {
        private MealOfTheDay(string value) {
            Value = value;
        }

        public string Value { get; private set; }

        public static MealOfTheDay BREAKFAST { get { return new MealOfTheDay("breakfast"); } }
        public static MealOfTheDay LUNCH { get { return new MealOfTheDay("lunch"); } }
        public static MealOfTheDay DINNER { get { return new MealOfTheDay("dinner"); } }
        public static MealOfTheDay SNACK { get { return new MealOfTheDay("snack"); } }
        public static MealOfTheDay SUPPER { get { return new MealOfTheDay("supper"); } }
    }
}
