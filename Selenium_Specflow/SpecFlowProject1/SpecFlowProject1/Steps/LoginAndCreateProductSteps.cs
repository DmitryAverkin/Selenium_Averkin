using Basics_Averkin.Business;
using Basics_Averkin.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class LoginAndCreateProductSteps
    {
        private IWebDriver driver;
        private UserPassword user = new UserPassword("user", "user");
        private Product product = new Product("Pear", "Seafood", "Tokyo Traders", "55", "30", "35", "20", "10", "discontinued");

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
        
        [When(@"I enter the login and password and click button")]
        public void WhenIEnterTheLoginAndPasswordAndClickButton()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization(user);
            Thread.Sleep(1000);
        }

        [When(@"I click on the button ""(.*)""")]
        public void WhenIClickOnTheButton(string p0)
     
        {
            new HomePage(driver).createproduct();
            Thread.Sleep(1000);
        }
        
        [When(@"Now i click on the button ""(.*)""")]
        public void WhenNowIClickOnTheButton(string p0)
        { 
            new AllProducts(driver).createnew();
            Thread.Sleep(1000);
        }
        
        [When(@"I fill all the fields of the product and click button")]
        public void WhenIFillAllTheFieldsOfTheProductAndClickButton()
        {
            new ProductEditing(driver).addproduct(product);
            Thread.Sleep(1000);
        }
        
        [Then(@"Product created")]
        public void ThenProductCreated()
        {
           AllProducts allProducts = new AllProducts(driver);
           ProductEditing productEditing = allProducts.openproduct();
           
           Thread.Sleep(1000);

           Assert.AreEqual("Pear", productEditing.productname.GetAttribute("value"));
           Assert.IsTrue(productEditing.сategory.Text.Contains("Seafood"));
           Assert.IsTrue(productEditing.supplier.Text.Contains("Tokyo Traders"));
           Assert.AreEqual("55,0000", productEditing.unitprice.GetAttribute("value"));
           Assert.AreEqual("30", productEditing.quantityperunit.GetAttribute("value"));
           Assert.AreEqual("35", productEditing.unitsinstock.GetAttribute("value"));
           Assert.AreEqual("20", productEditing.unitsonorder.GetAttribute("value"));
           Assert.AreEqual("10", productEditing.reorderlevel.GetAttribute("value"));

           driver.Quit();
        }
       
    }
}
