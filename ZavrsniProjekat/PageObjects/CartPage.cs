using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ZavrsniProjekat.PageObjects
{
    class CartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement ShippingColumn
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//tr[contains(.,'Shipping')]/td[3]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement ButtonContinueShopping
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[contains(., 'Continue shopping')]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement ButtonCheckout
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("checkout"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public HomePage ClickContinueShopping()
        {
            this.ButtonContinueShopping?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new HomePage(this.driver);
        }

        public ConfirmationPage ClickCheckout()
        {
            this.ButtonCheckout?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'You have successfully placed your order.')]")));
            return new ConfirmationPage(this.driver);
        }

    }
}
