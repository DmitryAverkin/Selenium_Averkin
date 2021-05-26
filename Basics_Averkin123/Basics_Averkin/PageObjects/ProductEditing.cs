using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Averkin.PageObjects
{
    class ProductEditing : AbstractClass
    {
        public ProductEditing(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
            [FindsBy(How = How.Id, Using = "ProductName")]
            private IWebElement productname;

            [FindsBy(How = How.Id, Using = "CategoryId")]
            private IWebElement сategory;

            [FindsBy(How = How.Id, Using = "SupplierId")]
            private IWebElement supplier;

            [FindsBy(How = How.Id, Using = "UnitPrice")]
            private IWebElement unitprice;

            [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
            private IWebElement quantityperunit;

            [FindsBy(How = How.Id, Using = "UnitsInStock")]
            private IWebElement unitsinstock;

            [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
            private IWebElement unitsonorder;

            [FindsBy(How = How.Id, Using = "ReorderLevel")]
            private IWebElement reorderlevel;

            [FindsBy(How = How.Id, Using = "Discontinued")]
            private IWebElement discontinued;

            [FindsBy(How = How.XPath, Using = "//input [@type='submit']")]
            private IWebElement button;
        
        public void addproduct() 
        {
            new Actions(driver)
                .SendKeys(productname, "Pear")
                .Click(сategory)
                .SendKeys("Seafood")
                .Click(supplier)
                .SendKeys("Tokyo Traders")
                .SendKeys(unitprice, "45")
                .SendKeys(quantityperunit, "30")
                .SendKeys(unitsinstock, "35")
                .SendKeys(unitsonorder, "20")
                .SendKeys(reorderlevel, "10")
                .Click(discontinued)
                .Click(button)
                .Build()
                .Perform();
            
            }
         public ProductEditing check()
        {
            Assert.AreEqual("Pear", productname.GetAttribute("value"));
            Assert.IsTrue(сategory.Text.Contains("Seafood"));
            Assert.IsTrue(supplier.Text.Contains("Tokyo Traders"));
            Assert.AreEqual("45,0000", unitprice.GetAttribute("value"));
            Assert.AreEqual("30", quantityperunit.GetAttribute("value"));
            Assert.AreEqual("35", unitsinstock.GetAttribute("value"));
            Assert.AreEqual("20", unitsonorder.GetAttribute("value"));
            Assert.AreEqual("10", reorderlevel.GetAttribute("value"));

            return new ProductEditing(driver);
        }


    }
}
