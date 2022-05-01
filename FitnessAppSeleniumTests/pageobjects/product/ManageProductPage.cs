using FitnessAppSeleniumTests.model.entity;
using OpenQA.Selenium;

namespace FitnessAppSeleniumTests.pageobjects
{
    public class ManageProductPage : BaseFitAppPage
    {
        private const string PRODUCT_NAME = "ProductName";
        private const string KCAL = "Calories";
        private const string PROTEINS = "Proteins";
        private const string FATS = "Fats";
        private const string CARBS = "Carbohydrates";
        private const string MORE_INFO_BTN = "moreInfoBtn";
        private const string VIT_A = "VitaminA";
        private const string VIT_B1 = "VitaminB1";
        private const string VIT_B2 = "VitaminB2";
        private const string VIT_B5 = "VitaminB5";
        private const string VIT_B6 = "VitaminB6";
        private const string BIOTIN = "Biotin";
        private const string FOLIC_ACID = "FolicAcid";
        private const string VIT_B12 = "VitaminB12";
        private const string VIT_C = "VitaminC";
        private const string VIT_D = "VitaminD";
        private const string VIT_E = "VitaminE";
        private const string VIT_PP = "VitaminPp";
        private const string VIT_K = "VitaminK";
        private const string ZINC = "Zinc";
        private const string PHOSPHORUS = "Phosphorus";
        private const string IODINE = "Iodine";
        private const string MAGNESIUM = "Magnesium";
        private const string COPPER = "Copper";
        private const string POTASSIUM = "Potassium";
        private const string SELENIUM = "Selenium";
        private const string SODIUM = "Sodium";
        private const string CALCIUM = "Calcium";
        private const string IRON = "Iron";
        private const string SUBMIT = "input[type='submit']";

        public void FillForm(Product p)
        {
            FillField(By.Id(PRODUCT_NAME), p.Name);
            FillField(By.Id(KCAL), p.Kcal);
            FillField(By.Id(PROTEINS), p.Proteins);
            FillField(By.Id(FATS), p.Fats);
            FillField(By.Id(CARBS), p.Carbohydrates);

            Click(By.Id(MORE_INFO_BTN));

            FillField(By.Id(VIT_A), p.VitaminA);
            FillField(By.Id(VIT_B1), p.VitaminB1);
            FillField(By.Id(VIT_B2), p.VitaminB2);
            FillField(By.Id(VIT_B5), p.VitaminB5);
            FillField(By.Id(VIT_B6), p.VitaminB6);
            FillField(By.Id(BIOTIN), p.Biotin);
            FillField(By.Id(FOLIC_ACID), p.FolicAcid);
            FillField(By.Id(VIT_B12), p.VitaminB12);
            FillField(By.Id(VIT_C), p.VitaminC);
            FillField(By.Id(VIT_D), p.VitaminD);
            FillField(By.Id(VIT_E), p.VitaminE);
            FillField(By.Id(VIT_PP), p.VitaminPP);
            FillField(By.Id(VIT_K), p.VitaminK);
            FillField(By.Id(ZINC), p.Zinc);
            FillField(By.Id(PHOSPHORUS), p.Phosphorus);
            FillField(By.Id(IODINE), p.Iodine);
            FillField(By.Id(MAGNESIUM), p.Magnesium);
            FillField(By.Id(COPPER), p.Copper);
            FillField(By.Id(POTASSIUM), p.Potassium);
            FillField(By.Id(SELENIUM), p.Selenium);
            FillField(By.Id(SODIUM), p.Sodium);
            FillField(By.Id(CALCIUM), p.Calcium);
            FillField(By.Id(IRON), p.Iron);
        }

        public bool CompareProductDataToObject(Product product)
        {
            bool basicDataCompatible = 
                FindElementAndGetValue(By.Id(PRODUCT_NAME)).Equals(product.Name) &&
                FindElementAndGetValue(By.Id(KCAL)).Equals(product.Kcal) &&
                FindElementAndGetValue(By.Id(PROTEINS)).Equals(product.Proteins) &&
                FindElementAndGetValue(By.Id(FATS)).Equals(product.Fats) &&
                FindElementAndGetValue(By.Id(CARBS)).Equals(product.Carbohydrates);

            Click(By.Id(MORE_INFO_BTN));

            bool moreInfoCompatible = 
                FindElementAndGetValue(By.Id(VIT_A)).Equals(product.VitaminA) &&
                FindElementAndGetValue(By.Id(VIT_B1)).Equals(product.VitaminB1) &&
                FindElementAndGetValue(By.Id(VIT_B2)).Equals(product.VitaminB2) &&
                FindElementAndGetValue(By.Id(VIT_B5)).Equals(product.VitaminB5) &&
                FindElementAndGetValue(By.Id(VIT_B6)).Equals(product.VitaminB6) &&
                FindElementAndGetValue(By.Id(BIOTIN)).Equals(product.Biotin) &&
                FindElementAndGetValue(By.Id(FOLIC_ACID)).Equals(product.FolicAcid) &&
                FindElementAndGetValue(By.Id(VIT_B12)).Equals(product.VitaminB12) &&
                FindElementAndGetValue(By.Id(VIT_C)).Equals(product.VitaminC) &&
                FindElementAndGetValue(By.Id(VIT_D)).Equals(product.VitaminD) &&
                FindElementAndGetValue(By.Id(VIT_E)).Equals(product.VitaminE) &&
                FindElementAndGetValue(By.Id(VIT_PP)).Equals(product.VitaminPP) &&
                FindElementAndGetValue(By.Id(VIT_K)).Equals(product.VitaminK) &&
                FindElementAndGetValue(By.Id(ZINC)).Equals(product.Zinc) &&
                FindElementAndGetValue(By.Id(PHOSPHORUS)).Equals(product.Phosphorus) &&
                FindElementAndGetValue(By.Id(IODINE)).Equals(product.Iodine) &&
                FindElementAndGetValue(By.Id(MAGNESIUM)).Equals(product.Magnesium) &&
                FindElementAndGetValue(By.Id(COPPER)).Equals(product.Copper) &&
                FindElementAndGetValue(By.Id(POTASSIUM)).Equals(product.Potassium) &&
                FindElementAndGetValue(By.Id(SELENIUM)).Equals(product.Selenium) &&
                FindElementAndGetValue(By.Id(SODIUM)).Equals(product.Sodium) &&
                FindElementAndGetValue(By.Id(CALCIUM)).Equals(product.Calcium) &&
                FindElementAndGetValue(By.Id(IRON)).Equals(product.Iron);

            return basicDataCompatible && moreInfoCompatible;
        }

        public ProductPage Submit()
        {
            Click(By.CssSelector(SUBMIT));
            return new ProductPage();
        }
    }
}
