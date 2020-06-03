using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ZavrsniProjekat.Library
{
    class UsefulHelpers
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public static string RandomEmail()
        {
            string email_part1, email_part2, email_part3;
            email_part1 = RandomAlphaNumeric(5);
            email_part2 = RandomAlphaNumeric(5);
            email_part3 = "com";
            return email_part1 + "@" + email_part2 + "." + email_part3;
        }

        public static string RandomAlphaNumeric(int len = 3)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string RandomString(int len = 3)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
        public static string RandomPassword(int len = 10)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&-_";

            var builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
        public IWebElement GetElement(By by)
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

        public SelectElement GetSelect(By by)
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
    }
}
