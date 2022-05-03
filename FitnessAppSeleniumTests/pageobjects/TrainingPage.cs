using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects.training.strengthTraining;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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

        public MainPage GoBackToMainPage()
        {
            JavaScriptClick(By.XPath(MAIN_PAGE));
            return new MainPage();
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

        public ManageStrengthTrainingPage EditStrengthTraining(StrengthTraining strengthTraining)
        {
            IWebElement rowToEdit = FindStrengthTraining(strengthTraining);
            rowToEdit.FindElement(By.ClassName(NAME)).Click();
            return new ManageStrengthTrainingPage();
        }

        public void DeleteStrengthTraining(StrengthTraining strengthTraining)
        {
            FindStrengthTraining(strengthTraining).FindElement(By.Id(DELETE)).Click();
            IWebElement deleteBtn = FindElement(By.CssSelector("#formDeleteStrength .deleteBtn"));
            WaitForElementToBeClickable(deleteBtn);
            deleteBtn.Click();
        }

        public IWebElement FindStrengthTraining(StrengthTraining strengthTraining)
        {
            PaginationUtils.GoToLastPage();
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

        private IWebElement GetLastStrengthRow()
        {
            IList<IWebElement> strengthTraining = FindElements(By.ClassName("strengthTraining"));
            if(strengthTraining.Count > 0) {
                return strengthTraining[strengthTraining.Count - 1];
            }
            throw new RowNotFoundException();
        }

    }
}
