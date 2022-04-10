using FitnessAppSeleniumTests.framework.config;
using FitnessAppSeleniumTests.pageobjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.tests
{
    public class BaseFitAppTest
    {
        private const string URL = "https://localhost:44315/";

        [SetUp]
        public void SetUpBeforeTest()
        {
            Config.GetDriver().Navigate().GoToUrl(URL);
            LoginPage loginPage = new LoginPage();
            loginPage.LogIn();
        }

        [TearDown]
        public void TearDown()
        {
            Config.GetDriver().Quit();
        }
    }
}
