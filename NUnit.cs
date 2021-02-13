using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Learning2020.AutomationPractice.com
{
    [TestFixture]
    public class NUnit
    {
        public IWebDriver driver;
        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void CreateNewAccountSignoutAndSighnIn()
        {
            AutomationPractice automationPractice = new AutomationPractice(driver);
            automationPractice.OpenWebpage();
            automationPractice.RegisterAnAccount();
            Thread.Sleep(3000);
            automationPractice.ReturnToHomePage();
            Thread.Sleep(3000);
            automationPractice.SignOut();
            Thread.Sleep(3000);
            automationPractice.SignIn();
        }
        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
