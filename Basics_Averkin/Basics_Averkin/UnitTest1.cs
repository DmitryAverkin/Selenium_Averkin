using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

        }
        public void log()
        {
            IWebElement login = driver.FindElement(By.XPath("//input[@id ='Name']"));
            IWebElement password = driver.FindElement(By.XPath("//input[@id ='Password']"));
            IWebElement button = driver.FindElement(By.XPath("//input[@type='submit']"));
            login.SendKeys("user");
            password.SendKeys("user");
            button.Click();
        }

        [Test]
        public void Test1()
        {
            log ();
        
            Assert.AreEqual("Logout", driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Text);
        }

        [Test]
        public void Test2()
        {
            log();

            IWebElement allproduct = driver.FindElement(By.XPath("(//a[@href='/Product'])[1]"));
            allproduct.Click();
            IWebElement create = driver.FindElement(By.XPath("//a[@class='btn btn-default']"));
            create.Click();
            IWebElement productname = driver.FindElement(By.Id("ProductName"));
            productname.SendKeys("Pear");
            IWebElement category = driver.FindElement(By.XPath("//option[contains(text(),'Seafood')]"));
            category.Click();
            IWebElement supplier = driver.FindElement(By.XPath("//option [contains(text(),'Tokyo Traders')]"));
            supplier.Click();
            IWebElement unitprice = driver.FindElement(By.Id("UnitPrice"));
            unitprice.SendKeys("45");
            IWebElement quantityperunit = driver.FindElement(By.Id("QuantityPerUnit"));
            quantityperunit.SendKeys("30");
            IWebElement unitsinstock = driver.FindElement(By.Id("UnitsInStock"));
            unitsinstock.SendKeys("35");
            IWebElement unitsonorder = driver.FindElement(By.Id("UnitsOnOrder"));
            unitsonorder.SendKeys("20");
            IWebElement reorderlevel = driver.FindElement(By.Id("ReorderLevel"));
            reorderlevel.SendKeys("10");
            IWebElement discontinued = driver.FindElement(By.Id("Discontinued"));
            discontinued.Click();
            IWebElement button2 = driver.FindElement(By.XPath("//input [@type='submit']"));
            button2.Click();
            Assert.AreEqual("Pear", driver.FindElement(By.XPath("(//a[contains(text(),'Pear')])[2]")).Text);
        }

        [Test]
        public void Test3()
        {
            log();

            IWebElement allproduct = driver.FindElement(By.XPath("(//a[@href='/Product'])[1]"));
            allproduct.Click();
            IWebElement pear = driver.FindElement(By.XPath("(//a[contains(text(),'Pear')])[2]"));
            pear.Click();
            IWebElement productname = driver.FindElement(By.Id("ProductName"));
            Assert.AreEqual("Pear", productname.GetAttribute("value"));
            IWebElement category = driver.FindElement(By.XPath("//option[contains(text(),'Seafood')]"));
            Assert.AreEqual("Seafood", category.Text);
            IWebElement supplier = driver.FindElement(By.XPath("//option [contains(text(),'Tokyo Traders')]"));
            Assert.AreEqual("Tokyo Traders", supplier.Text);
            IWebElement unitprice = driver.FindElement(By.Id("UnitPrice"));
            Assert.AreEqual("45,0000", unitprice.GetAttribute("value"));
            IWebElement quantityperunit = driver.FindElement(By.Id("QuantityPerUnit"));
            Assert.AreEqual("30", quantityperunit.GetAttribute("value"));
            IWebElement unitsinstock = driver.FindElement(By.Id("UnitsInStock"));
            Assert.AreEqual("35", unitsinstock.GetAttribute("value"));
            IWebElement unitsonorder = driver.FindElement(By.Id("UnitsOnOrder"));
            Assert.AreEqual("20", unitsonorder.GetAttribute("value"));
            IWebElement reorderlevel = driver.FindElement(By.Id("ReorderLevel"));
            Assert.AreEqual("10", reorderlevel.GetAttribute("value"));
         
        }
        [Test]
        public void Test4()
        {
            log();

            IWebElement allproduct = driver.FindElement(By.XPath("(//a[@href='/Product'])[1]"));
            allproduct.Click();
            IWebElement remove = driver.FindElement(By.XPath("(//a[contains(text(),'Remove')]) [78]"));
            remove.Click();
            driver.SwitchTo().Alert().Accept();
        }
            [Test]
            public void Test5()
            
            {
                log();

            IWebElement logout = driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
            logout.Click();
            IWebElement login = driver.FindElement(By.XPath("//h2[contains(text(),'Login')]"));
            Assert.IsTrue(login.Text.Contains("Login"));
            }
            
            [TearDown]
            public void TearDown()
            {
            driver.Quit();
            }

    }
}