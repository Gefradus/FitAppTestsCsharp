using FitnessAppSeleniumTests.framework.config;
using FitnessAppSeleniumTests.pageobjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FitnessAppSeleniumTests.tests
{
    public class BaseFitAppTest
    {
        private const string URL = "http://localhost:5000";

        [OneTimeSetUp]
        public void SetUpBeforeTest()
        {
            Config.GetDriver().Navigate().GoToUrl(URL);
            LoginPage loginPage = new LoginPage();
            loginPage.LogIn();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Config.CloseDriver();

        }
    }
}
