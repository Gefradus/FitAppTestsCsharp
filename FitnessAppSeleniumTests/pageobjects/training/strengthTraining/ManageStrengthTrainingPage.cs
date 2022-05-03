using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.training.strengthTraining {

    public class ManageStrengthTrainingPage : BaseFitAppPage
    {
        private const string EDIT_SETS_FIELD = "#editStrengthModal #sets";
        private const string EDIT_REPS_FIELD = "#editStrengthModal #reps";
        private const string EDIT_WEIGHT_FIELD = "#editStrengthModal #weight";
        private const string EDIT_STRENGTH_TRAINING = "editStrengthTraining";

        public TrainingPage FillFormAndSubmit(StrengthTraining strengthTraining)
        {
            FillField(By.CssSelector(EDIT_SETS_FIELD), strengthTraining.Sets);
            FillField(By.CssSelector(EDIT_REPS_FIELD), strengthTraining.Reps);
            FillField(By.CssSelector(EDIT_WEIGHT_FIELD), strengthTraining.Weight);
            Click(By.Id(EDIT_STRENGTH_TRAINING));
            return new TrainingPage();
        }
    }

}
