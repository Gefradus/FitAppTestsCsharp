namespace FitnessAppSeleniumTests.model.enums
{
    public class DaysOfTheWeek
    {
        private DaysOfTheWeek(string value) {
            Value = value;
        }

        public string Value { get; private set; }

        public static DaysOfTheWeek MONDAY { get { return new DaysOfTheWeek("Monday"); } }
        public static DaysOfTheWeek TUESDAY { get { return new DaysOfTheWeek("Tuesday"); } }
        public static DaysOfTheWeek WEDNESDAY { get { return new DaysOfTheWeek("Wednesday"); } }
        public static DaysOfTheWeek THURSDAY { get { return new DaysOfTheWeek("Thursday"); } }
        public static DaysOfTheWeek FRIDAY { get { return new DaysOfTheWeek("Friday"); } }
        public static DaysOfTheWeek SATURDAY { get { return new DaysOfTheWeek("Saturday"); } }
        public static DaysOfTheWeek SUNDAY { get { return new DaysOfTheWeek("Sunday"); } }
    }
}
