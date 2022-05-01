using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class TrainingPage : BaseFitAppPage
    {
        private const string DELETE = "btnDelete";
        private const string NAME = "trainingName";
        private const string KCAL_BURNED = "kcalBurned";
        private const string TIME_IN_MINUTES = "timeInMinutes";
        private const string SETS = "setsView";
        private const string REPS = "repsView";
        private const string LOAD = "loadView";

        private const string MAIN_PAGE = "//a[./img[@id='logoPink']]";

        public MainPage GoBackToMainPage()
        {
            JavaScriptClick(By.XPath(MAIN_PAGE));
            return new MainPage();
        } 


    }
}
