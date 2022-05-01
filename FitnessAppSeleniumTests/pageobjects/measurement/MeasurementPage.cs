using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class MeasurementPage : BaseFitAppPage
    {
        private const string DIV = "div";
        private const string EDIT = "edit";
        private const string DELETE = "delete";
        private const string TABLE_ROWS = ".table .rowM";
        private const string BTN_SHOW_MODAL_ADD_MEASUREMENT = "btnShowModalAddMeasurement";

        public ManageMeasurementPage AddMeasurement()
        {
            Click(By.Id(BTN_SHOW_MODAL_ADD_MEASUREMENT));
            return new ManageMeasurementPage();
        }

        public bool MeasurementExists(Measurement measurement)
        {
            try {
                FindMeasurement(measurement);
                return true;
            } 
            catch(RowNotFoundException) {
                return false;
            }
        }

        public IWebElement FindMeasurement(Measurement measurement)
        {
            PaginationUtils.GoToLastPage();
            IList<IWebElement> tableRows = FindElements(By.CssSelector(TABLE_ROWS));
            IWebElement lastRow = tableRows[tableRows.Count - 1];
            if (VerifyLastRowHasTheSameDataAsMeasurement(measurement, lastRow.FindElements(By.TagName(DIV)))) {
                return lastRow;
            } else { 
                throw new RowNotFoundException();
            }
        }

        private bool VerifyLastRowHasTheSameDataAsMeasurement(Measurement measurement, IList<IWebElement> lastRowDivs)
        {
            bool hasLastRowTheSameWeightAsEntity = measurement.Weight.Equals(lastRowDivs[0].Text.Trim());
            bool hasLastRowTheSameWaistAsEntity = measurement.Waist.Equals(lastRowDivs[1].Text.Trim());
            bool hasLastRowDateNow = DateFormatterUtils.CompareDateToNow(lastRowDivs[3].Text.Trim());
            return hasLastRowDateNow && hasLastRowTheSameWeightAsEntity && hasLastRowTheSameWaistAsEntity;
        }

        public ManageMeasurementPage EditMeasurement(Measurement measurement)
        {
            FindMeasurement(measurement).FindElement(By.ClassName(EDIT)).Click();
            return new ManageMeasurementPage();
        }

        public bool DeleteMeasurementAndVerifyIfDeleted(Measurement measurement)
        {
            int tableRowSizeBeforeDelete = FindElements(By.CssSelector(TABLE_ROWS)).Count;
            FindMeasurement(measurement).FindElement(By.ClassName(DELETE)).Click();
            IWebElement delete = FindElement(By.Id(DELETE));
            WaitForElementToBeClickable(delete);
            delete.Click();
            WaitForPageLoaded();
            return FindElements(By.CssSelector(TABLE_ROWS)).Count == tableRowSizeBeforeDelete - 1;
        }
    }
}
