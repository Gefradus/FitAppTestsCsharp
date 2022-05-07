using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.training.cardioTraining
{
    public class ManageCardioTrainingTypePage : BaseFitAppPage
    {
        private const string CARDIO_TYPE_NAME = "cardioTypeName";
        private const string EXPENDITURE = "expenditure";
        private const string ADD_TRAINING = "//button[contains(text(), 'Utwórz nowe ćwiczenie')]";

        public void FillForm(CardioTrainingType cardioTrainingType)
        {
            FillField(By.Id(CARDIO_TYPE_NAME), cardioTrainingType.Name);
            FillField(By.Id(EXPENDITURE), cardioTrainingType.Expenditure);
        }

        public CardioTrainingTypePage Submit()
        {
            Click(By.XPath(ADD_TRAINING));
            return new CardioTrainingTypePage();
        }
    }
}
