using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Edge;

namespace MusicAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driverPath = "http://localhost:5135";
            var options = new ChromeDriver(driverPath, options);
            var drivers = new ChromeDriver();
            /*var driver = new EdgeDriver(driverPath, options);
            var options = new EdgeOptions();
            var driver = new EdgeDriver(driverPath, options);*/
            /* var options = new FirefoxOptions();
             var driver = new FirefoxDriver(driverPath, options);*/
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}