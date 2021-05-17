using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab3Tests
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
        }

        [Test]
        public void Test3()
        {

           //Check if book Plato's "Republic" is available on Rozetka

            driver.Navigate().GoToUrl("https://www.google.com/");

            // Search Rozetka
            driver.FindElement(By.Name("q")).SendKeys("Розетка");
            Thread.Sleep(500);
            driver.FindElement(By.Name("btnK")).Submit();

            //Search for book
            driver.FindElement(By.ClassName("yuRUbf")).Click();
            driver.FindElement(By.Name("search")).SendKeys("Государство");
            driver.FindElement(By.CssSelector("button.button:nth-child(2)")).Click();

            //Check book page
          
            driver.FindElement(By.XPath("/html/body/app-root/div/div/rz-search/rz-catalog/div/div[2]/section/rz-grid/ul/li[1]/app-goods-tile-default/div/div[2]/a[2]/span")).Click();
            
            String actualResult = driver.FindElement(By.CssSelector(".status-label")).Text;
            String expectedResult = "Есть в наличии";

            Assert.AreEqual(actualResult, expectedResult);
            Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
