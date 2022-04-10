using System;
using System.Linq;

namespace FitnessAppSeleniumTests.framework.config.basicmethods
{
    public class StringUtils
    {
        private static readonly Random random = new Random();

        private const char SPACE = ' ';
        private const string AUTOMATIC = "AUTOMAT";
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomEntityName()
        {
            const int length = 10;
            return RandomEntityName(length);
        }

        public static string RandomEntityName(int length)
        {
            string randomString = new string(Enumerable.Repeat(CHARS, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return AUTOMATIC + SPACE + randomString;
        }
    }
}
