using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.training.strengthTraining;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests.strengthTraining
{
    public class StrengthTrainingTest : BaseFitAppTest
    {
        private TrainingPage trainingPage;
        private StrengthTraining strengthTraining;
        private StrengthTrainingTypePage strengthTrainingTypePage;

        [Test, Order(1)]
        public void AddStrengthTraining()
        {
            strengthTraining = StrengthTrainingDataProvider.StrengthTraining();
            strengthTrainingTypePage = new MainPage().GetTrainings().AddStrengthTraining();
            ManageStrengthTrainingTypePage manageStrengthTrainingTypePage = strengthTrainingTypePage.AddStrengthTrainingType();
            manageStrengthTrainingTypePage.FillForm(strengthTraining);
            trainingPage = manageStrengthTrainingTypePage.Submit();
            Assert.True(trainingPage.StrengthTrainingExists(strengthTraining));
        }

        [Test, Order(2)]
        public void EditStrengthTraining()
        {
            ManageStrengthTrainingPage manageStrengthTrainingPage = trainingPage.EditStrengthTraining(strengthTraining);
            StrengthTraining editedStrengthTraining = StrengthTrainingDataProvider.EditedStrengthTraining();
            trainingPage = manageStrengthTrainingPage.FillFormAndSubmit(editedStrengthTraining);
            bool trainingExists = trainingPage.StrengthTrainingExists(editedStrengthTraining);
            if (trainingExists) strengthTraining = editedStrengthTraining;
            Assert.True(trainingExists);
        }

        [Test, Order(3)]
        public void DeleteStrengthTraining()
        {
            trainingPage.DeleteStrengthTraining(strengthTraining);
            Assert.False(trainingPage.StrengthTrainingExists(strengthTraining));
        }

        public void DeleteStrengthTrainingType()
        {

        }
    }
}
