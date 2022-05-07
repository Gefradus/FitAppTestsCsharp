using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects.admin
{
    public class AdminTrainingsPage : BaseFitAppPage
    {
        private const string DELETE = "delete";
        private const string DELETE_STRENGTH_BTN = "#formDeleteStrength .deleteBtn";
        private const string DELETE_CARDIO_BTN = "#formDeleteCardio .deleteBtn";
        private const string SEARCH_STRENGTH = "searchStrength";
        private const string SEARCH_CARDIO = "searchCardio";
        private const string STRENGTH_TRAINING_ROWS = "#strengthTable .tableRow";
        private const string CARDIO_TRAINING_ROWS = "#cardioTable .tableRow";

        public void DeleteStrengthTrainingType(StrengthTrainingType strengthTrainingType)
        {
            DeleteRow(FindStrengthTrainingType(strengthTrainingType), FindElement(By.CssSelector(DELETE_STRENGTH_BTN)));
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

        private IWebElement FindCardioTrainingType(CardioTrainingType cardioTrainingType)
        {
            WaitForPageLoaded();
            FillField(By.Id(SEARCH_CARDIO), cardioTrainingType.Name);
            Submit(By.Id(SEARCH_CARDIO));
            IList<IWebElement> cardioTrainingRows = FindElements(By.CssSelector(CARDIO_TRAINING_ROWS));
            if (cardioTrainingRows.Count > 0)
            {
                return cardioTrainingRows[0];
            }
            throw new RowNotFoundException();
        }

        private void DeleteRow(IWebElement row, IWebElement delete)
        {
            row.FindElement(By.ClassName(DELETE)).Click();
            WaitForElementToBeClickable(delete);
            delete.Click();
        }

        public void DeleteCardioTrainingType(CardioTrainingType cardioTrainingType)
        {
            DeleteRow(FindCardioTrainingType(cardioTrainingType), FindElement(By.CssSelector(DELETE_CARDIO_BTN)));
        }
    }
}
