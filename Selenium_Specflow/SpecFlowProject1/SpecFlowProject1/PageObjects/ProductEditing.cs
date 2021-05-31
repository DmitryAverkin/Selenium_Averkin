using Basics_Averkin.Business;
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
            public IWebElement productname;

            [FindsBy(How = How.Id, Using = "CategoryId")]
            public IWebElement сategory;

            [FindsBy(How = How.Id, Using = "SupplierId")]
            public IWebElement supplier;

            [FindsBy(How = How.Id, Using = "UnitPrice")]
            public IWebElement unitprice;

            [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
            public IWebElement quantityperunit;

            [FindsBy(How = How.Id, Using = "UnitsInStock")]
            public IWebElement unitsinstock;

            [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
            public IWebElement unitsonorder;

            [FindsBy(How = How.Id, Using = "ReorderLevel")]
            public IWebElement reorderlevel;

            [FindsBy(How = How.Id, Using = "Discontinued")]
            public IWebElement discontinued;

            [FindsBy(How = How.XPath, Using = "//input [@type='submit']")]
            public IWebElement button;
        
        public AllProducts addproduct(Product product) 
        {
            new Actions(driver)
                .SendKeys(productname, product.product)
                .Click(сategory)
                .SendKeys(product.сategory)
                .Click(supplier)
                .SendKeys(product.supplier)
                .SendKeys(unitprice, product.unitprice)
                .SendKeys(quantityperunit, product.quantityperunit)
                .SendKeys(unitsinstock, product.unitsinstock)
                .SendKeys(unitsonorder, product.unitsonorder)
                .SendKeys(reorderlevel, product.reorderlevel)
                .Click(discontinued)
                .Click(button)
                .Build()
                .Perform();
                
            return new AllProducts(driver);
            }
       

    }
}
