using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
namespace FitnessAppSeleniumTests.pageobjects
{
    public class ManageMeasurementPage : BaseFitAppPage
    {
        private const string ADD = "btnAddMeasurement";
        private const string EDIT = "btnEditMeasurement";
        private const string WEIGHT = "weight";
        private const string WAIST = "waist";

        public void FillForm(Measurement measurement)
        {
            WaitForElementToBeClickable(FindElement(By.Id(WEIGHT)));
            FillField(By.Id(WEIGHT), measurement.Weight);
            FillField(By.Id(WAIST), measurement.Waist);
        }

        public MeasurementPage Submit(bool edit)
        {
            IWebElement submitBtn = FindElement(By.Id(edit ? EDIT : ADD));
            submitBtn.Click();
            return new MeasurementPage();
        }
    }
}
