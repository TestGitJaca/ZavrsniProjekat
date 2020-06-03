using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ZavrsniProjekat.PageObjects;
using ShopQaHomePage = ZavrsniProjekat.PageObjects.HomePage;
using ShopQaLoginPage = ZavrsniProjekat.PageObjects.LoginPage;
using ShopQaCartPage = ZavrsniProjekat.PageObjects.CartPage;
using ShopQaRegistar = ZavrsniProjekat.PageObjects.Registar;
using ShopQaConfirmationPage = ZavrsniProjekat.PageObjects.ConfirmationPage;
using Excel = Microsoft.Office.Interop.Excel;
using ZavrsniProjekat.Library;
using UsefulHelpers = ZavrsniProjekat.Library.UsefulHelpers;
using System.Threading;

namespace ZavrsniProjekat
{
    class TestClass
    {
        private IWebDriver driver;
        private CSVHandler CSV;
        
        public string TestData_Email = UsefulHelpers.RandomEmail();
        public string TestData_String = UsefulHelpers.RandomString();
        public string TestData_password = UsefulHelpers.RandomPassword();

        [Test]

        public void TestShopQaRsOrderPro()
        {
            ShopQaRegistar register = new Registar(driver);
            ShopQaHomePage home = new ShopQaHomePage(driver);
            ShopQaLoginPage login = new ShopQaLoginPage(driver);
            UsefulHelpers helper = new UsefulHelpers();
            home.GoToPage();
            home.ClickOnRegisterLink();
            string firstName = "User" + TestData_String;
            string lastName = "New" + TestData_String;
            string email = TestData_Email;
            string username = "Someuser" + TestData_String;
            string password = TestData_password;
            register.RegisterUser(firstName, lastName, email, username, password);
            home.ClickOnLoginLink();
            login.Login(username, password);
            //Excel.Worksheet Sheet;
            //Sheet = this.CSV.OpenCSV(@"D:\Users\login.csv");
            //int rows = Sheet.UsedRange.Rows.Count;
            ///int columns = Sheet.UsedRange.Columns.Count;

            //if ((rows <= 1) || (columns < 2))
            //{
            //    this.LogLine("FAIL - Not enough data to proceed with login");
            //    Assert.Fail("Not enough data to proceed with login");
            //}
            //string username = Sheet.Cells[2, 1].Value;
            //string password = Sheet.Cells[2, 2].Value;
            //this.CSV.Close();

            //ShopQaHomePage home = new ShopQaHomePage(driver);
            //ShopQaLoginPage login = new ShopQaLoginPage(driver);
            //home.GoToPage();
            //home.ClickOnLoginLink();
            //home = login.Login(username, password);
            Excel.Worksheet Sheet;
            if (home.WelcomeBack != null) // Successful login
            {
                Sheet = this.CSV.OpenCSV(@"D:\Users\test-pro-order.csv");
                int rows = Sheet.UsedRange.Rows.Count;
                int columns = Sheet.UsedRange.Columns.Count;

                if ((rows <= 1) || (columns < 2))
                {
                    this.LogLine("FAIL - Not enough data to proceed with tests");
                    Assert.Fail("Not enough data to proceed with tests");
                }

                ShopQaCartPage cart;
                ShopQaConfirmationPage confirmation;
                //bool hasFail = false;
                string name, quantity;
                for (int i = 2; i <= rows; i++)
                {
                    name = Sheet.Cells[i, 1].Value;
                    quantity = Convert.ToString(Sheet.Cells[i, 2].Value);
                    //// shipping = Convert.ToString(Sheet.Cells[i, 3].Value);
                    // if (shipping != "FREE")
                    // {
                    //     shipping = $"${shipping}";
                    // }

                    home.SelectQuantity(home.PackageProQuantity, quantity);
                    cart = home.ClickOnOrderPro();
                    home = cart.ClickContinueShopping();
                }

                this.CSV.Close();
                this.CSV = null;
                cart = home.ClickOnViewCart();
                Thread.Sleep(5000);
                confirmation = cart.ClickCheckout();
                home = confirmation.ClickGoBack();
                confirmation.ViewHistoryClick();
                string text = confirmation.OrderAmount.Text;
                string expected = "4800.00";
                Assert.AreEqual(text, expected);

            }
        }

        [SetUp]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();
            this.driver.Manage().Window.Maximize();
            this.CSV = new CSVHandler();
        }

        [TearDown]
        public void TearDown()
        {
            if (this.driver != null)
            {
                this.driver.Close();
            }
            if (this.CSV != null)
            {
                this.CSV.Close();
            }
        }

        private void LogLine(string Message)
        {
            FileManagement.WriteLine(Message);
            TestContext.WriteLine(Message);
        }

        private void Log(string Message)
        {
            FileManagement.Write(Message);
            TestContext.Write(Message);
        }
    }
}
