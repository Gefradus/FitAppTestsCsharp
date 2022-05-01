using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects.training.strengthTraining
{
    public class StrengthTrainingTypePage : BaseFitAppPage
    {
        private const string CREATE_TRAINING = "createTraining";
        private const string TRAINING_ROWS = "#trainingPanel .training";
        private const string SEARCH = "search";
        private const string BACK_TO_MAIN_PAGE = "//a[./img[@id='logoPink']]";

        public ManageStrengthTrainingTypePage AddStrengthTrainingType()
        {
            Click(By.Id(CREATE_TRAINING));
            return new ManageStrengthTrainingTypePage();        
        }
        
        public IWebElement FindStrengthTrainingType(StrengthTrainingType strengthTrainingType) {
            FillField(By.Id(SEARCH), strengthTrainingType.Name);
            Submit(By.Id(SEARCH));
            WaitForPageLoaded();
            IList<IWebElement> trainingRows = FindElements(By.CssSelector(TRAINING_ROWS));
            if (trainingRows.Count > 0)
            {
                return trainingRows[0];
            }
            else
            {
                throw new RowNotFoundException();
            }
        }

        public MainPage GoBackToMainPage()
        {
            JavaScriptClick(By.XPath(BACK_TO_MAIN_PAGE));
            return new MainPage();  
        }
    }
}
