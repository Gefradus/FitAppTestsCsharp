using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.training.cardioTraining
{
    public class ManageCardioTrainingPage : BaseFitAppPage
    {
        private const string TIME_IN_MINUTES = "timeInMinutes";
        private const string BURNED_KCAL = "burnedKcal";
        private const string EDIT_CARDIO = "editCardio";
        private const string ADD_CARDIO = "addCardio";

        public void FillForm(CardioTraining cardioTraining)
        {
            FillField(By.Id(TIME_IN_MINUTES), cardioTraining.TimeInMinutes);
            FillField(By.Id(BURNED_KCAL), cardioTraining.KcalBurned);
        }

        public TrainingPage Submit(bool edit)
        {
            Click(By.Id(edit ? EDIT_CARDIO : ADD_CARDIO));
            return new TrainingPage();
        }
    }
}
