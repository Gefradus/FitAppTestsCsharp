using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.tests.measurement;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests
{
    public class MeasurementTest : BaseFitAppTest
    {
        private Measurement measurement;
        private MeasurementPage measurementPage;

        [Test, Order(1)]
        public void AddMeasurement()
        {
            measurement = MeasurementDataProvider.Measurement();
            measurementPage = new MainPage().GetMeasurements();
            ManageMeasurementPage manageMeasurementPage = measurementPage.AddMeasurement();
            manageMeasurementPage.FillForm(measurement);
            measurementPage = manageMeasurementPage.Submit(false);
            Assert.True(measurementPage.MeasurementExists(measurement), "Added measurement not found");
        }

        [Test, Order(2)]
        public void EditMeasurement()
        {
            Measurement measurement = MeasurementDataProvider.EditedMeasurement();
            ManageMeasurementPage manageMeasurementPage = measurementPage.EditMeasurement(this.measurement);
            manageMeasurementPage.FillForm(measurement);
            measurementPage = manageMeasurementPage.Submit(true);
            bool measurementExists = measurementPage.MeasurementExists(measurement);
            if (measurementExists) this.measurement = measurement;
            Assert.True(measurementExists, "Edited measurement not found");
        }

        [OneTimeTearDown]
        public void DeleteMeasurement()
        {
            Assert.True(measurementPage.DeleteMeasurementAndVerifyIfDeleted(measurement), 
                "Number of rows is the same as before delete");
        }
    }
}
