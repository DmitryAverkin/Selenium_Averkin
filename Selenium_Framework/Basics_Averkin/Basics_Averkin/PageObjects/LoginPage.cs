using Basics_Averkin.Business;
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
    class LoginPage : AbstractClass
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id ='Name']")]
        private IWebElement login;

        [FindsBy(How = How.XPath, Using = "//input[@id ='Password']")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement button;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")]
        private IWebElement logout;


        public HomePage autorization(UserPassword user)
        {
            new Actions(driver).SendKeys(login, user.Name).SendKeys(password, user.Password).Click(button).Build().Perform();
            
            return new HomePage(driver);
        }
        public LoginPage logoutuser()
        {
            new Actions(driver).Click(logout).Build().Perform();
            return new LoginPage(driver);
            
        }

    }
}
