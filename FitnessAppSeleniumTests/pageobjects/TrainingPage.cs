using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects.training.cardioTraining;
using FitnessAppSeleniumTests.pageobjects.training.strengthTraining;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class TrainingPage : BaseFitAppPage
    {
        private const string DELETE = "btnDelete";
        private const string NAME = "trainingName";
        private const string KCAL_BURNED = "kcalBurned";
        private const string TIME_IN_MINUTES = "timeInMinutes";
        private const string SETS = "setsView";
        private const string REPS = "repsView";
        private const string LOAD = "loadView";

        private const string MAIN_PAGE = "//a[./img[@id='logoPink']]";
        private const string BTN_ADD_STRENGTH = "btnAddStrength";
        private const string BTN_ADD_CARDIO = "btnAddCardio";
        private const string STRENGTH_TRAINING = "strengthTraining";
        private const string CARDIO_TRAINING = "cardioTraining";
        private const string STRENGTH_PAGINATION = "strengthPagination";
        private const string CARDIO_PAGINATION = "cardioPagination";
        private const string DELETE_STRENGTH_BTN = "#formDeleteStrength .deleteBtn";
        private const string DELETE_CARDIO_BTN = "#formDeleteCardio .deleteBtn";

        public MainPage GoBackToMainPage()
        {
            JavaScriptClick(By.XPath(MAIN_PAGE));
            return new MainPage();
        }
        
        public CardioTrainingTypePage AddCardioTraining()
        {
            Click(By.Id(BTN_ADD_CARDIO));
            return new CardioTrainingTypePage();
        }

        public StrengthTrainingTypePage AddStrengthTraining()
        {
            Click(By.Id(BTN_ADD_STRENGTH));
            return new StrengthTrainingTypePage();
        }

        public bool StrengthTrainingExists(StrengthTraining strengthTraining)
        {
            try {
                FindStrengthTraining(strengthTraining); 
                return true;
            } 
            catch (RowNotFoundException) {
                return false;
            }
        }

        public bool CardioTrainingExists(CardioTraining cardioTraining)
        {
            try
            {
                FindCardioTraining(cardioTraining);
                return true;
            }
            catch (RowNotFoundException)
            {
                return false;
            }
        }

        public ManageCardioTrainingPage EditCardioTraining(CardioTraining cardioTraining)
        {
            IWebElement rowToEdit = FindCardioTraining(cardioTraining);
            rowToEdit.FindElement(By.ClassName(NAME)).Click();
            return new ManageCardioTrainingPage();
        }

        public ManageStrengthTrainingPage EditStrengthTraining(StrengthTraining strengthTraining)
        {
            IWebElement rowToEdit = FindStrengthTraining(strengthTraining);
            rowToEdit.FindElement(By.ClassName(NAME)).Click();
            return new ManageStrengthTrainingPage();
        }

        public int CardioTrainingSize()
        {
            return FindElements(By.ClassName(CARDIO_TRAINING)).Count;
        }

        public void DeleteStrengthTraining(StrengthTraining strengthTraining)
        {
            FindStrengthTraining(strengthTraining).FindElement(By.Id(DELETE)).Click();
            IWebElement deleteBtn = FindElement(By.CssSelector(DELETE_STRENGTH_BTN));
            WaitForElementToBeClickable(deleteBtn);
            deleteBtn.Click();
        }

        public void DeleteCardioTraining(CardioTraining cardioTraining)
        {
            FindCardioTraining(cardioTraining).FindElement(By.Id(DELETE)).Click();
            IWebElement deleteBtn = FindElement(By.CssSelector(DELETE_CARDIO_BTN));
            WaitForElementToBeClickable(deleteBtn);
            deleteBtn.Click();
            WaitForPageLoaded();
        } 

        public bool VerifyIfCardioDeleted(CardioTraining cardioTraining, int cardioTrainingsSizeBeforeDelete)
        {
            return !CardioTrainingExists(cardioTraining) && CardioTrainingSize() == cardioTrainingsSizeBeforeDelete - 1;
        }

        public IWebElement FindCardioTraining(CardioTraining cardioTraining)
        {
            PaginationUtils.GoToLastPage(By.Id(CARDIO_PAGINATION));
            IWebElement lastRow = GetLastCardioRow();
            string lastRowName = lastRow.FindElement(By.ClassName(NAME)).Text.Trim();
            string lastRowKcalBurned = lastRow.FindElement(By.ClassName(KCAL_BURNED)).Text.Trim();
            string lastRowTimeInMinutes = lastRow.FindElement(By.ClassName(TIME_IN_MINUTES)).Text.Trim();

            bool hasLastRowTheSameName = cardioTraining.CardioTrainingType.Name.Equals(lastRowName);
            bool hasLastRowTheSameKcalBurned = cardioTraining.KcalBurned.Equals(lastRowKcalBurned);
            bool hasLastRowTheSameTimeInMinutes = cardioTraining.TimeInMinutes.Equals(lastRowTimeInMinutes);
            if (hasLastRowTheSameName && hasLastRowTheSameKcalBurned && hasLastRowTheSameTimeInMinutes)
                return lastRow;
            throw new RowNotFoundException();
        }

        public IWebElement FindStrengthTraining(StrengthTraining strengthTraining)
        {
            PaginationUtils.GoToLastPage(By.Id(STRENGTH_PAGINATION));
            IWebElement lastRow = GetLastStrengthRow();
            string lastRowName = lastRow.FindElement(By.ClassName(NAME)).Text.Trim();
            string lastRowSets = lastRow.FindElement(By.ClassName(SETS)).Text.Trim();
            string lastRowReps = lastRow.FindElement(By.ClassName(REPS)).Text.Trim();
            string lastRowLoad = lastRow.FindElement(By.ClassName(LOAD)).Text.Trim();

            bool hasLastRowTheSameName = strengthTraining.TrainingType.Name.Equals(lastRowName);
            bool hasLastRowTheSameSets = strengthTraining.Sets.Equals(lastRowSets);
            bool hasLastRowTheSameReps = strengthTraining.Reps.Equals(lastRowReps);
            bool hasLastRowTheSameLoad = strengthTraining.Weight.Equals(lastRowLoad);
            if (hasLastRowTheSameName && hasLastRowTheSameSets && hasLastRowTheSameReps && hasLastRowTheSameLoad)
                return lastRow;
            throw new RowNotFoundException();
        }
        private IWebElement GetLastCardioRow()
        {
            IList<IWebElement> strengthTraining = FindElements(By.ClassName(CARDIO_TRAINING));
            if (strengthTraining.Count > 0)
            {
                return strengthTraining[strengthTraining.Count - 1];
            }
            throw new RowNotFoundException();
        }

        private IWebElement GetLastStrengthRow()
        {
            IList<IWebElement> strengthTraining = FindElements(By.ClassName(STRENGTH_TRAINING));
            if(strengthTraining.Count > 0) {
                return strengthTraining[strengthTraining.Count - 1];
            }
            throw new RowNotFoundException();
        }

    }
}
