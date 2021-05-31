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
    public class LogoutSteps
    {
        new private IWebDriver driver;
        private UserPassword user = new UserPassword("user", "user");

        [Given(@"I open the last time ""(.*)"" url")]
        public void GivenIOpenTheLastTimeUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [When(@"I enter the last time the login and password and click button")]
        public void WhenIEnterTheLastTimeTheLoginAndPasswordAndClickButton()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization(user);
            Thread.Sleep(1000);
        }

        [When(@"And Now i click on the button ""(.*)""")]
        public void WhenAndNowIClickOnTheButton(string p0)
        {
            new LoginPage(driver).logoutuser();
            Thread.Sleep(1000);
        }

        [Then(@"The login page is opened")]
        public void ThenTheLoginPageIsOpened()
        {
            Assert.AreEqual("Login", driver.FindElement(By.XPath("//h2[contains(text(),'Login')]")).Text);

            driver.Quit();
        }

    }

}
