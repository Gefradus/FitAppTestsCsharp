using FitnessAppSeleniumTests.model.entity;
using FitnessAppSeleniumTests.pageobjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppSeleniumTests.tests
{
    public class ProductTest : BaseFitAppTest
    {
        private Product product;
        private ProductPage productPage;

        [Test]
        public void AddProduct()
        {
            product = ProductDataProvider.Product();
            productPage = new MainPage().GetProducts();
            ManageProductPage manageProductPage = productPage.AddProduct();
            manageProductPage.FillForm(product);
            productPage = manageProductPage.Submit();
            Assert.True(productPage.ProductExists(product));
        }

        public void EditProduct()
        {

        }
    }
}
