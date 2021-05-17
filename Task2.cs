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
        public void Test2()
        {


            //search
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.Name("q")).SendKeys("Епіцентр");
            driver.FindElement(By.Name("q")).Submit();
            driver.FindElement(By.ClassName("yuRUbf")).Click();
            driver.FindElement(By.ClassName("header__info-menu")).Click();
            driver.FindElement(By.ClassName("is-red")).Click();

            //check schedule
            String actualResult = driver.FindElement(By.XPath("/html/body/main/div[2]/div/section/h3")).Text;
            String expectedResult = "Контакт-центр працює для Вас щоденно з 07:30 до 22:30.";
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
