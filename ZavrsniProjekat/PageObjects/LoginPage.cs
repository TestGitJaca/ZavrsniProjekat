using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ZavrsniProjekat.Library;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Registar = ZavrsniProjekat.PageObjects.Registar;

namespace ZavrsniProjekat.PageObjects
{
    class LoginPage

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement UsernameInput
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("username")));
                    element = this.driver.FindElement(By.Name("username"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement PasswordInput
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("password")));
                    element = this.driver.FindElement(By.Name("password"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("login")));
                    element = this.driver.FindElement(By.Name("login"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }


        public void ClickLoginButton()
        {
            this.LoginButton?.Click();
            wait.Until(EC.ElementIsVisible(By.CssSelector("h3.panel-title")));

        }
        public HomePage Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            ClickLoginButton();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new HomePage(this.driver);
        }
    }
}
