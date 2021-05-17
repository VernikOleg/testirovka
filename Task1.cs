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
        public void Test1()
        {
            //search
            driver.Navigate().GoToUrl("https://www.google.com/");       
            driver.FindElement(By.Name("q")).SendKeys("Розклад КПІ");
            driver.FindElement(By.Name("q")).Submit();
            driver.FindElement(By.ClassName("yuRUbf")).Click();
            //check
            driver.FindElement(By.Id("ctl00_MainContent_ctl00_txtboxGroup")).SendKeys("КП-92");
            driver.FindElement(By.Id("ctl00_MainContent_ctl00_txtboxGroup")).Click();
            driver.FindElement(By.Id("ctl00_MainContent_ctl00_btnShowSchedule")).Click();
            String actualResult = driver.FindElement(By.XPath("/html/body/div/form/div[5]/div[1]/table/tbody/tr[2]/td[4]/span/a")).GetAttribute("title");
            String expectedResult = "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення";
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
