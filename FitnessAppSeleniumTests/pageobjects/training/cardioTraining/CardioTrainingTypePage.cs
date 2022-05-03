using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppSeleniumTests.pageobjects.training.cardioTraining
{
    public class CardioTrainingTypePage : BaseFitAppPage
    {
        private const string CREATE_TRAINING = "createTraining";


        public ManageCardioTrainingTypePage AddCardioTrainingType()
        {
            Click(By.Id(CREATE_TRAINING));
            return new ManageCardioTrainingTypePage();
        }

        /*public ManageCardioTrainingTypePage AddCardioTraining()
        {

        }*/
    }
}
