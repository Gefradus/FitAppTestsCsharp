using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.training.strengthTraining
{
    public class ManageStrengthTrainingTypePage : BaseFitAppPage
    {
        private const string STRENGTH_TRAINING_TYPE_NAME = "strengthTrainingTypeName";
        private const string ADD_TRAINING_TYPE = "#addTrainingType .modal-body button";
        private const string WEIGHT = "weightT";
        private const string SETS = "setsT";
        private const string REPS = "repsT";

        public void FillForm(StrengthTraining strengthTraining)
        {
            FillField(By.Id(STRENGTH_TRAINING_TYPE_NAME), strengthTraining.TrainingType.Name);
            FillField(By.Id(SETS), strengthTraining.Sets);
            FillField(By.Id(REPS), strengthTraining.Reps);
            FillField(By.Id(WEIGHT), strengthTraining.Weight);
        }

        public TrainingPage Submit()
        {
            JavaScriptClick(By.CssSelector(ADD_TRAINING_TYPE));
            WaitForPageLoaded();
            return new TrainingPage();
        }
    }
}
