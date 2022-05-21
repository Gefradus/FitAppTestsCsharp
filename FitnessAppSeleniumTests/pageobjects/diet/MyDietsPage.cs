using FitnessAppSeleniumTests.framework.config.basicmethods;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FitnessAppSeleniumTests.pageobjects.diet
{
    public class MyDietsPage : BaseFitAppPage
    {
        private const string DIET_NAME = "dietName";
        private const string TABLE_ROW = "tableRow";
        private const string EDIT_DIET = "editDiet";
        private const string DELETE_DIET = "deleteDiet";
        private const string DELETE_CONFIRM = "delete";

        public bool VerifyDietExists(Diet diet)
        {
            try
            {
                FindDiet(diet);
                return true;
            } catch (RowNotFoundException)
            {
                return false;
            }
        }

        public IWebElement FindDiet(Diet diet)
        {
            PaginationUtils.GoBackToFirstPage();
            while (PaginationUtils.HasViewNextPage())
            {
                IWebElement dietRow = FindDietInRows(diet);
                if (dietRow != null) return dietRow;
                PaginationUtils.GoToNextPage();
            }
            IWebElement dietRow2 = FindDietInRows(diet);
            if (dietRow2 != null) return dietRow2;
            throw new RowNotFoundException();
        }

        public IWebElement FindDietInRows(Diet diet)
        {
            IList<IWebElement> dietRows = FindElements(By.ClassName(TABLE_ROW));
            foreach(IWebElement row in dietRows)
            {
                string lastRowDietName = row.FindElement(By.ClassName(DIET_NAME)).Text.Trim();
                if (lastRowDietName.Equals(diet.Name))
                    return row;
            }
            return null;
        }

        public ManageDietPage EditDiet(Diet diet)
        {
            IWebElement dietToEdit = FindDiet(diet);
            dietToEdit.FindElement(By.ClassName(EDIT_DIET)).Click();
            WaitForPageLoaded();
            return new ManageDietPage();
        }

        public void DeleteDiet(Diet diet)
        {
            IWebElement dietToDelete = FindDiet(diet);
            dietToDelete.FindElement(By.ClassName(DELETE_DIET)).Click();
            WaitForPageLoaded();
            Click(By.Id(DELETE_CONFIRM));
            WaitForPageLoaded();
        }
    }
}
