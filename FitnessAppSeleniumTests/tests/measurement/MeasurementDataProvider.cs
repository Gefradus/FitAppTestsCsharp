using FitnessAppSeleniumTests.model.entity;

namespace FitnessAppSeleniumTests.tests.measurement
{
    internal class MeasurementDataProvider
    {
        public static Measurement Measurement()
        {
            return new Measurement()
            {
                Weight = "100",
                Waist = "150"
            };
        }

        public static Measurement EditedMeasurement()
        {
            return new Measurement()
            {
                Weight = "200",
                Waist = "300"
            };
        }
    }
}
