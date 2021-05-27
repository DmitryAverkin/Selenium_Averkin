using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basics_Averkin.PageObjects
{
    class AllProducts : AbstractClass
    {
        public AllProducts(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-default']")]
        private IWebElement create;

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'Pear')])[2]")]
        private IWebElement pear;

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'Remove')])[78]")]
        private IWebElement remove;
        
        public ProductEditing createnew()
        {
            create.Click();

            return new ProductEditing(driver);
        }

        public ProductEditing openproduct()
        {
            pear.Click();

            return new ProductEditing(driver);
        }

         public AllProducts deleteproduct()
        {
            new Actions(driver).Click(remove).Build().Perform();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            
            return new AllProducts(driver);
        }
        }
    
}
