using Basics_Averkin.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Basics_Averkin
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();

        }
      
        [Test]
        public void Test1()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization();

            Assert.AreEqual("Logout", driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Text);
        }
          
        [Test]
        public void Test2()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization();
            Thread.Sleep(2000);

            AllProducts allProducts = homePage.createproduct();
            Thread.Sleep(2000);

            ProductEditing productEditing = allProducts.createnew();
            Thread.Sleep(2000);
            
            productEditing.addproduct();
            Thread.Sleep(2000);
            
            Assert.AreEqual("Pear", driver.FindElement(By.XPath("(//a[contains(text(),'Pear')])[2]")).Text);
        }
        [Test]
        public void Test3()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization();
            Thread.Sleep(2000);

            AllProducts allProducts = homePage.createproduct();
            Thread.Sleep(2000);

            ProductEditing productEditing = allProducts.openproduct();
            Thread.Sleep(2000);

            productEditing.check();
            Thread.Sleep(2000);

        }

        [Test]
        public void Test4()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization();
            Thread.Sleep(2000);

            AllProducts allProducts = homePage.createproduct();
            Thread.Sleep(2000);
            allProducts.deleteproduct();

        }

        [Test]
        public void Test5()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization();
            Thread.Sleep(2000);

            loginPage.logoutuser();

            Assert.AreEqual("Login", driver.FindElement(By.XPath("//h2[contains(text(),'Login')]")).Text);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}