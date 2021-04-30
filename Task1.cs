using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab3TestCases
{
    class Task1
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            // Checking schedule of student group

            String targer = "КП-92";
            driver.Navigate().GoToUrl("http://rozklad.kpi.ua/Schedules/ScheduleGroupSelection.aspx");

            //Searching for target
            driver.FindElement(By.Id("ctl00_MainContent_ctl00_txtboxGroup")).SendKeys(targer);
            driver.FindElement(By.Id("ctl00_MainContent_ctl00_btnShowSchedule")).Click();

            //Comparing results
            String actualResult = driver.FindElement(By.XPath("/html/body/div/form/div[5]/div[1]/table/tbody/tr[2]/td[4]/span/a")).GetAttribute("title");
            String expectedResult = "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення";

            Assert.AreEqual(actualResult, expectedResult);
            Thread.Sleep(2000);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}