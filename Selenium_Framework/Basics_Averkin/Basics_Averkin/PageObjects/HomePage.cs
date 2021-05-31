using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Averkin.PageObjects
{
    class HomePage : AbstractClass
    {

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
            [FindsBy(How = How.XPath, Using = "(//a[@href='/Product'])[1]")]
            private IWebElement allproduct;

        public AllProducts createproduct()
        {
            allproduct.Click();
            
            return new AllProducts(driver);


        }
    }
}
