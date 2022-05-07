using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.admin;
using FitnessAppSeleniumTests.pageobjects.training.cardioTraining;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests.cardioTraining
{
    public class CardioTrainingTest : BaseFitAppTest
    {
        private CardioTrainingTypePage cardioTrainingTypePage;
        private CardioTraining cardioTraining;
        private TrainingPage trainingPage;

        public void AddCardioTrainingType(CardioTrainingType cardioTrainingType) {
            cardioTrainingTypePage = new MainPage().GetTrainings().AddCardioTraining();
            ManageCardioTrainingTypePage manageCardioTrainingTypePage = cardioTrainingTypePage.AddCardioTrainingType();
            manageCardioTrainingTypePage.FillForm(cardioTrainingType);
            cardioTrainingTypePage = manageCardioTrainingTypePage.Submit();
            Assert.True(cardioTrainingTypePage.CardioTrainingTypeExists(cardioTrainingType), 
                "Added cardio training type not found");
        }

        [Test, Order(1)]
        public void AddCardioTraining()
        {
            CardioTraining cardioTraining = CardioTrainingDataProvider.CardioTraining();
            AddCardioTrainingType(cardioTraining.CardioTrainingType);
            ManageCardioTrainingPage manageCardioTrainingPage = cardioTrainingTypePage.AddCardioTraining(cardioTraining);
            manageCardioTrainingPage.FillForm(cardioTraining);
            trainingPage = manageCardioTrainingPage.Submit(false);
            this.cardioTraining = cardioTraining;
            Assert.True(trainingPage.CardioTrainingExists(cardioTraining));
        }

        [Test, Order(2)]
        public void EditCardioTraining()
        {
            ManageCardioTrainingPage manageCardioTrainingPage = trainingPage.EditCardioTraining(cardioTraining);
            CardioTraining editedCardioTraining = CardioTrainingDataProvider.EditedCardioTraining();
            manageCardioTrainingPage.FillForm(editedCardioTraining);
            trainingPage = manageCardioTrainingPage.Submit(true);
            bool cardioTrainingExists = trainingPage.CardioTrainingExists(editedCardioTraining);
            if (cardioTrainingExists) cardioTraining = editedCardioTraining;
            Assert.True(cardioTrainingExists);
        }

        [Test, Order(3)]
        public void DeleteCardioTraining()
        {
            TrainingPage trainingPage = new MainPage().GetTrainings();
            int cardioTrainingsSizeBeforeDelete = trainingPage.CardioTrainingSize();
            trainingPage.DeleteCardioTraining(cardioTraining);
            Assert.True(new MainPage().GetTrainings().VerifyIfCardioDeleted(cardioTraining, cardioTrainingsSizeBeforeDelete));
        }

        [OneTimeTearDown]
        public void DeleteCardioTrainingType()
        {
            AdminTrainingsPage adminTrainingsPage = trainingPage.GoBackToMainPage().GetAdmin().GetTrainings();
            adminTrainingsPage.DeleteCardioTrainingType(cardioTraining.CardioTrainingType);
        }
    }
}
