using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.diet
{
    public class DietPage : BaseFitAppPage
    {
        private const string SHOW_MY_DIETS = "showMyDiets";
        private const string CREATE_DIET = "createDiet";

        public ManageDietPage AddDiet()
        {
            Click(By.Id(CREATE_DIET));
            return new ManageDietPage();
        }

        public MyDietsPage ShowMyDiets()
        {
            Click(By.Id(SHOW_MY_DIETS));
            return new MyDietsPage();
        }
    }
}
