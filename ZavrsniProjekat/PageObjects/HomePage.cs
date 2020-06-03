using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ZavrsniProjekat.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs/");
        }

        public IWebElement LinkLogin
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/login']")));
                    element = this.driver.FindElement(By.XPath("//a[@href='/login']"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement LinkRegister
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/register']")));
                    element = this.driver.FindElement(By.XPath("//a[@href='/register']"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement WelcomeBack
        {
            get
            {
                IWebElement element = null;
                try
                {
                    //wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
                    element = this.driver.FindElement(By.XPath("//h2[contains(text(), 'Welcome back,')]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement LinkLogout
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/logout']"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }


        public IWebElement PackagePro
        {
            get
            {
                IWebElement element;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//h3[contains(., 'pro')]//parent::div//following-sibling::div")));
                    element = this.driver.FindElement(By.XPath("//h3[contains(., 'pro')]//parent::div//following-sibling::div"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public IWebElement PackageProQuantity
        {
            get
            {
                IWebElement element;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//h3[contains(., 'pro')]//parent::div//following-sibling::div//select")));
                    element = this.driver.FindElement(By.XPath("//h3[contains(., 'pro')]//parent::div//following-sibling::div//select"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public IWebElement PackageProOrder
        {
            get
            {
                IWebElement element;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//h3[contains(., 'pro')]//parent::div//following-sibling::div//input[@type='submit']")));
                    element = this.driver.FindElement(By.XPath("//h3[contains(., 'pro')]//parent::div//following-sibling::div//input[@type='submit']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public IWebElement LinkViewCart
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.PartialLinkText("View shopping cart"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }

        public Registar ClickOnRegisterLink()
        {
            this.LinkRegister?.Click();
            wait.Until(EC.ElementIsVisible(By.Name("ime")));
            return new Registar(this.driver);
        }


        public LoginPage ClickOnLoginLink()
        {
            this.LinkLogin?.Click();
            wait.Until(EC.ElementIsVisible(By.ClassName("form-signin-heading")));
            return new LoginPage(this.driver);
        }

        public void SelectQuantity(IWebElement element, string quantity)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(quantity);
        }

        public CartPage ClickOnOrderPro()
        {
            this.PackageProOrder?.Click();
            wait.Until(EC.ElementIsVisible(By.CssSelector("body > div:nth-child(2) > div:nth-child(2) > table")));
            return new CartPage(this.driver);
        }

        public CartPage ClickOnViewCart()
        {
            this.LinkViewCart?.Click();
            wait.Until(EC.ElementIsVisible(By.CssSelector("body > div:nth-child(2) > div:nth-child(2) > table")));
            return new CartPage(this.driver);
        }

    }
}
