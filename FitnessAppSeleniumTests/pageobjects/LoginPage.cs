using OpenQA.Selenium;
using FitnessAppSeleniumTests.framework.config;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class LoginPage : BaseFitAppPage
    {
        private const string LOG_SIDE = "logSide";
        private const string PASSWORD = "Password";
        private const string LOGIN_OR_EMAIL = "LoginOrEmail";
        private const string ADMIN = "admin";
        private const string SUBMIT = "button[type='submit']";

        public void LogIn()
        {
            IWebElement logSide = Config.GetDriver().FindElement(By.Id(LOG_SIDE));
            WaitForElementToBeClickable(logSide);
            logSide.FindElement(By.Id(LOGIN_OR_EMAIL)).SendKeys(ADMIN);
            logSide.FindElement(By.Id(PASSWORD)).SendKeys(ADMIN);
            JavaScriptClick(logSide.FindElement(By.CssSelector(SUBMIT)));
        }
    }
}
