using System;

namespace FitnessAppSeleniumTests.framework.config.basicmethods
{
    public class RowNotFoundException : Exception
    {
        public RowNotFoundException() : base("Row not found") {}
    }
}
