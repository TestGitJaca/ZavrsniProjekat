using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using HomePage = ZavrsniProjekat.PageObjects.HomePage;
using System.Linq;
//using UsefulFunctions = Zavrsni_rad.Library.UsefulFunctions;
using System.Collections.ObjectModel;

namespace ZavrsniProjekat.PageObjects
{
    class Registar
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public Registar(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        private SelectElement GetSelect(By by)
        {
            IWebElement element;
            SelectElement select;
            try
            {
                wait.Until(EC.ElementIsVisible(by));
                element = this.driver.FindElement(by);
                select = new SelectElement(element);
            }
            catch (Exception)
            {
                select = null;
            }
            return select;
        }
        public IWebElement FirstName
        {
            get
            {
                return this.GetElement(By.Name("ime"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.GetElement(By.Name("prezime"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return this.GetElement(By.Name("korisnicko"));
            }
        }
        public IWebElement Password
        {
            get
            {
                return this.GetElement(By.Name("lozinka"));
            }
        }
        public IWebElement ConfirmPassword
        {
            get
            {
                return this.GetElement(By.Name("lozinkaOpet"));
            }
        }
        public IWebElement Email
        {
            get
            {
                return this.GetElement(By.Name("email"));
            }
        }
        public IWebElement Phone
        {
            get
            {
                return this.GetElement(By.Name("telefon"));
            }
        }
        public IWebElement RegisterButton
        {
            get
            {
                return this.GetElement(By.Name("register"));
            }
        }
        public IWebElement SuccessAlert
        {
            get
            {
                wait.Until(EC.ElementIsVisible(By.CssSelector(".alert-success")));
                return this.GetElement(By.CssSelector(".alert-success"));
            }
        }

        public string RegisterUser(string firstName, string lastName, string email, string nickName, string pass)
        {

            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Email.SendKeys(email);
            UserName.SendKeys(nickName);

            Password.SendKeys(pass);
            ConfirmPassword.SendKeys(pass);
            RegisterButton.Click();

            return nickName;
        }


    }
}

