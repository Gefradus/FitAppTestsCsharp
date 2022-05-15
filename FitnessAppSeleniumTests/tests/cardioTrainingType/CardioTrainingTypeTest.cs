using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.admin;
using FitnessAppSeleniumTests.pageobjects.training.cardioTraining;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests.cardioTrainingType
{
    public class CardioTrainingTypeTest : BaseFitAppTest
    {
        private CardioTrainingType cardioTrainingType;
        private CardioTrainingTypePage cardioTrainingTypePage;

        [Test]
        public void AddCardioTrainingType()
        {
            cardioTrainingType = CardioTrainingTypeDataProvider.CardioTrainingType();
            cardioTrainingTypePage = new MainPage().GetTrainings().AddCardioTraining();
            ManageCardioTrainingTypePage manageCardioTrainingTypePage = cardioTrainingTypePage.AddCardioTrainingType();
            manageCardioTrainingTypePage.FillForm(cardioTrainingType);
            cardioTrainingTypePage = manageCardioTrainingTypePage.Submit();
            Assert.True(cardioTrainingTypePage.CardioTrainingTypeExists(cardioTrainingType));
        }

        [OneTimeTearDown]
        public void DeleteCardioTrainingType()
        {
            AdminTrainingsPage adminTrainingsPage = cardioTrainingTypePage.GoBackToMainPage().GetAdmin().GetTrainings();
            adminTrainingsPage.DeleteCardioTrainingType(cardioTrainingType);
        }
    }
}
