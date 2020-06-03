using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ZavrsniProjekat.PageObjects
{
    class ConfirmationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement LinkGoBack
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[contains(.,'Go back')]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public HomePage ClickGoBack()
        {
            this.LinkGoBack?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new HomePage(this.driver);
        }

        public IWebElement ViewHistory
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/history']"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }
        public void ViewHistoryClick()
        {
            this.ViewHistory?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//table")));

        }
        public IWebElement OrderAmount
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//div[2]/table/tbody/tr[1]/td[3]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }
    }
}