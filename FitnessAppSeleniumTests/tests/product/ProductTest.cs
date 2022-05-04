using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using FitnessAppSeleniumTests.pageobjects.admin;
using NUnit.Framework;

namespace FitnessAppSeleniumTests.tests
{
    public class ProductTest : BaseFitAppTest
    {
        private Product product;
        private ProductsPage productPage;

        [Test, Order(1)]
        public void AddProduct()
        {
            product = ProductDataProvider.Product();
            productPage = new MainPage().GetProducts();
            ManageProductPage manageProductPage = productPage.AddProduct();
            manageProductPage.FillForm(product);
            productPage = manageProductPage.Submit();
            Assert.True(productPage.ProductExists(product));
        }

        [Test, Order(2)]
        public void EditProduct()
        {
            AdminProductsPage adminProductsPage = productPage.GoBackToMainPage().GetAdmin().GetProducts();
            ManageProductPage manageProductPage = adminProductsPage.EditProduct(product);
            Product editedProduct = ProductDataProvider.EditedProduct();
            manageProductPage.FillForm(editedProduct);
            manageProductPage.Submit();
            adminProductsPage.EditProduct(editedProduct);
            bool wasProductEdited = manageProductPage.CompareProductDataToObject(editedProduct);
            if (wasProductEdited) product = editedProduct;
            Assert.True(wasProductEdited);
        }

        [OneTimeTearDown]
        public void DeleteProduct()
        {
            AdminProductsPage adminProductsPage = productPage.GoBackToMainPage().GetAdmin().GetProducts();
            adminProductsPage.DeleteProduct(product);
        }
    }
}
