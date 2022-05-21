using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.diet;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests.diet
{
    public class DietTest : BaseFitAppTest
    {
        private Diet diet;
        private ProductsPage productsPage;
        private MyDietsPage myDietsPage;

        private void AddDietProduct(Diet diet)
        {
            foreach (var dietProduct in diet.ProductsOfDiet) {
                Product product = dietProduct.Product;
                productsPage = new MainPage().GetProducts();
                ManageProductPage manageProductPage = productsPage.AddProduct();
                manageProductPage.FillForm(product);
                productsPage = manageProductPage.Submit();
                Assert.True(productsPage.ProductExists(product));
            }
        }

        [Test, Order(1)]
        public void AddDiet()
        {
            diet = DietDataProvider.Diet();
            AddDietProduct(diet);
            ManageDietPage manageDietPage = productsPage.GoBackToMainPage().GetDiets().AddDiet();
            myDietsPage = manageDietPage.FillAndSubmitForm(diet, false);
            Assert.True(myDietsPage.VerifyDietExists(diet));
        }

        [Test, Order(2)]
        public void EditDiet()
        {
            Diet editedDiet = DietDataProvider.EditedDiet();
            ManageDietPage manageDietPage = new MainPage().GetDiets().ShowMyDiets().EditDiet(diet);
            MyDietsPage myDietsPage = manageDietPage.FillAndSubmitForm(editedDiet, true);
            bool dietEdited = myDietsPage.VerifyDietExists(editedDiet);
            if (dietEdited) diet = editedDiet;
            Assert.True(dietEdited);
        }

        [Test, Order(3)]
        public void DeleteDiet()
        {
            myDietsPage.DeleteDiet(diet);
            Assert.False(myDietsPage.VerifyDietExists(diet));
        }
    }
}
