using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.model.enums;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects.diet
{
    public class ManageDietPage : BaseFitAppPage
    {
        private const string OVERRIDE = "yesOverride";
        private const string ID = "id";
        private const string ACTIVE = "active";
        private const string CHECKBOXES = ".ks-cboxtags li input";
        private const string BTN_ADD_PRODUCT = "btnAddProduct";
        private const string BTN_DELETE = "btnDelete";
        private const string SEARCH = "search";
        private const string ADD_PRODUCT_TO_DIET = ".searchPanel .btnAddProduct";
        private const string GRAMMAGE = "grammage";
        private const string ADD_PRODUCT = "button[onclick=\"tryAddProduct('/DietCreator/AddProduct')\"]";
        private const string CLOSE_MODAL = "close";
        private const string EDITED_NAME = "EditedDiet_DietName";
        private const string NAME = "ProductName";
        private const string SAVE_DIET = "saveDiet";
        private const string GO_BACK_TO_MY_DIETS = "a[href='/DietCreator/MyDiets']";

        public MyDietsPage FillAndSubmitForm(Diet diet, bool edit)
        {
            FillForm(diet, edit);
            SubmitAndOverrideIfNeeded();
            if(edit)
            {
                Click(By.CssSelector(GO_BACK_TO_MY_DIETS));
                return new MyDietsPage();
            }
            return new DietPage().ShowMyDiets();
        }

        private void FillForm(Diet diet, bool edit)
        {
            ClickCheckbox(By.Id(ACTIVE), diet.Active);
            CheckAllDaysOfTheWeek(diet);
            AddDietProduct(diet, edit);
            FillField(By.Id(edit ? EDITED_NAME : NAME), diet.Name);
        }

        private void CheckAllDaysOfTheWeek(Diet diet)
        {
            foreach(IWebElement checkbox in FindElements(By.CssSelector(CHECKBOXES)))
            {
                bool checkboxToBeClicked = false;
                foreach(DaysOfTheWeek day in diet.DaysOfTheWeek)
                {
                    if(checkbox.GetAttribute(ID).Equals(day.Value))
                    {
                        checkboxToBeClicked = true;
                        break;
                    }
                }
                ClickCheckbox(checkbox, checkboxToBeClicked);
            }
        }

        private void SubmitAndOverrideIfNeeded()
        {
            Click(By.Id(SAVE_DIET));
            try
            {
                WaitForElementFoundByToBeClickable(By.Id(OVERRIDE));
                Click(By.Id(OVERRIDE));
            }
            catch {
            }
        }

        private void AddDietProduct(Diet diet, bool edit)
        {
            if(edit)
            {
                foreach(IWebElement delete in FindElements(By.ClassName(BTN_DELETE)))
                {
                    delete.Click();
                    WaitForPageLoaded();
                }
            }
            FindElement(By.Id(BTN_ADD_PRODUCT)).Click();
            diet.ProductsOfDiet.ForEach(product =>
            {
                FillField(By.Id(SEARCH), product.Product.Name);
                Submit(By.Id(SEARCH));
                WaitForPageLoaded();
                Click(By.CssSelector(ADD_PRODUCT_TO_DIET));
                FillField(By.Id(GRAMMAGE), product.Quantity);
                Click(By.CssSelector(ADD_PRODUCT));
                WaitForPageLoaded();
            });
            Click(By.ClassName(CLOSE_MODAL));
        }
    }
}
