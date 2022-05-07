using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppSeleniumTests.pageobjects.training.cardioTraining
{
    public class CardioTrainingTypePage : BaseFitAppPage
    {
        private const string CREATE_TRAINING = "createTraining";
        private const string SEARCH = "search";
        private const string TRAINING_ROWS = "#trainingPanel .training";

        public ManageCardioTrainingTypePage AddCardioTrainingType()
        {
            Click(By.Id(CREATE_TRAINING));
            return new ManageCardioTrainingTypePage();
        }

        public ManageCardioTrainingPage AddCardioTraining(CardioTraining cardioTraining)
        {
            IWebElement cardioTrainingType = FindCardioTrainingType(cardioTraining.CardioTrainingType);
            cardioTrainingType.Click();
            return new ManageCardioTrainingPage();
        }

        public IWebElement FindCardioTrainingType(CardioTrainingType cardioTrainingType)
        {
            FillField(By.Id(SEARCH), cardioTrainingType.Name);
            Submit(By.Id(SEARCH));
            WaitForPageLoaded();
            IList<IWebElement> trainingRows = FindElements(By.CssSelector(TRAINING_ROWS));
            if(trainingRows.Count > 0) {
                return trainingRows[0];
            } 
            else {
                throw new RowNotFoundException();
            }

        }

        public bool CardioTrainingTypeExists(CardioTrainingType cardioTrainingType)
        {
            try
            {
                FindCardioTrainingType(cardioTrainingType);
                return true;
            } catch(RowNotFoundException)
            {
                return false;
            }
        }
    }
}
