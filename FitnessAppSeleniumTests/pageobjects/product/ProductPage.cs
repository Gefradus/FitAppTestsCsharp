﻿using FitnessAppSeleniumTests.framework.config;
using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class ProductPage : BaseFitAppPage
    {
        private const string ADD_PRODUCT = "addProduct";
        private const string BACK_TO_MAIN_PAGE = "//a[./img[@id='logoPink']]";

        public ManageProductPage AddProduct()
        {
            Click(By.Id(ADD_PRODUCT));
            return new ManageProductPage();
        }

        private void FindProduct(Product product)
        {
            By searchInput = By.Id("searchInput");
            FillField(searchInput, product.Name);
            Submit(searchInput);
        }

        public bool ProductExists(Product product)
        {
            FindProduct(product);
            int count = FindElements(By.ClassName("tableRow")).Count;
            return count > 0;
        }

        public MainPage GoBackToMainPage()
        {
            JavaScriptClick(By.XPath(BACK_TO_MAIN_PAGE));
            return new MainPage();
        }
    }
}