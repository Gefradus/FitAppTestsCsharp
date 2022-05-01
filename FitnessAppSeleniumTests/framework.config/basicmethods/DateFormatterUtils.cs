using System;

namespace FitnessAppSeleniumTests.framework.config.basicmethods
{
    public class DateFormatterUtils
    {
        public static bool CompareDateToNow(string date)
        {
            return DateTime.Now.ToString("dd.MM.yyyy").Equals(date);
        }
    }
}
