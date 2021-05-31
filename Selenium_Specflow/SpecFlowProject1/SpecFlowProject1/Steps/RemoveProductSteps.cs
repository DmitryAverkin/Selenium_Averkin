using Basics_Averkin.Business;
using Basics_Averkin.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class RemoveProductSteps
    {
        private IWebDriver driver;
        private UserPassword user = new UserPassword("user", "user");

        [Given(@"I open again ""(.*)"" url")]
        public void GivenIOpenAgainUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [When(@"I enter again the login and password and click button")]
        public void WhenIEnterAgainTheLoginAndPasswordAndClickButton()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.autorization(user);
            Thread.Sleep(1000);
        }

        [When(@"I click again on the button ""(.*)""")]
        public void WhenIClickAgainOnTheButton(string p0)
        {
            new HomePage(driver).createproduct();
            Thread.Sleep(1000);
        }

        [Then(@"Product removal")]
        public void ThenProductRemoval()
        {
            new AllProducts(driver).deleteproduct();

            driver.Quit();
        }

    }
}
