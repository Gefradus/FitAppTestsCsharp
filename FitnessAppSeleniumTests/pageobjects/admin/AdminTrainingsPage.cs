using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects.admin
{
    public class AdminTrainingsPage : BaseFitAppPage
    {
        private const string DELETE = "delete";
        private const string DELETE_BTN = "#formDeleteStrength .deleteBtn";
        private const string SEARCH_STRENGTH = "searchStrength";
        private const string STRENGTH_TRAINING_ROWS = "#strengthTable .tableRow";

        public void DeleteStrengthTrainingType(StrengthTrainingType strengthTrainingType)
        {
            DeleteRow(FindStrengthTrainingType(strengthTrainingType), FindElement(By.CssSelector(DELETE_BTN)));
        }

        private IWebElement FindStrengthTrainingType(StrengthTrainingType strengthTrainingType)
        {
            WaitForPageLoaded();
            FillField(By.Id(SEARCH_STRENGTH), strengthTrainingType.Name);
            Submit(By.Id(SEARCH_STRENGTH));
            IList<IWebElement> strengthTrainingRows = FindElements(By.CssSelector(STRENGTH_TRAINING_ROWS));
            if(strengthTrainingRows.Count > 0)
            {
                return strengthTrainingRows[0];
            }
            throw new RowNotFoundException();
        }

        private void DeleteRow(IWebElement row, IWebElement delete)
        {
            row.FindElement(By.ClassName(DELETE)).Click();
            WaitForElementToBeClickable(delete);
            delete.Click();
        }

        public void DeleteCardioTrainingType()
        {

        }
    }
}
