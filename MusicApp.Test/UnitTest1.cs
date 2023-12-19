using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MusicAppTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string baseUrl = "https://656793a3defcab1178536427--famous-seahorse-2db09a.netlify.app/";

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            /*driver.Manage().Window.Maximize();*/
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestLogo()
        {

            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var logo = driver.FindElement(By.ClassName("logo-holder"));
            Assert.IsTrue(logo.Displayed);
        }

        [TestMethod]
        public void TestMenu()
        {

            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var menu = driver.FindElement(By.ClassName("menu"));
            Assert.IsTrue(menu.Displayed);
        }

        [TestMethod]
        public void TestSearchBar()
        {
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine("Running TestSearchBar...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".searchbar")).Displayed);
 
        }

        [TestMethod]
        public void TestSearchInput()
        {
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine("Running TestSearchBar...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

           
            driver.FindElement(By.CssSelector(".search-input")).SendKeys("too");
            driver.FindElement(By.CssSelector(".search-button")).Click();

  
        }

        [TestMethod]
        public void TestTableSorting()
        {
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine("Running TestTableSorting...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            Assert.IsTrue(driver.FindElement(By.ClassName("table")).Displayed);


            IWebElement titleElement = driver.FindElement(By.XPath("//th[@class='table-header'][contains(text(),'Title')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", titleElement);

        }

        [TestMethod]
        public void TestPlayIcon()
        {
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine("Running TestTestPlayIcon...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            IWebElement imageElement = driver.FindElement(By.CssSelector(".play-img"));

            Assert.IsTrue(imageElement.Displayed, "Image element is not displayed.");

            imageElement.Click();


        }


        [TestMethod]
        public void TestSortSubtitle()
        {
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine("Running TestSortSubtitle...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.CssSelector(".table-header")).Click();

            IWebElement titleElement = driver.FindElement(By.XPath("//th[@class='table-header'][contains(text(),'Subtitle')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", titleElement);

           
        }




        [TestMethod]
        public void TestTrendingSongsHeaderPresence()
        {
   
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var trendingSongsHeader = driver.FindElement(By.XPath("//h5[text()='Trending Songs']"));
            Assert.IsTrue(trendingSongsHeader.Displayed);
        }

        [TestMethod]
        public void TestNewSongsHeaderPresence()
        {
    
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var newSongsHeader = driver.FindElement(By.XPath("//h5[text()='New Songs']"));
            Assert.IsTrue(newSongsHeader.Displayed);
        }
    }
}
