using System;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support.UI;
using Selenium.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    public class TestBase
    {
        protected WebDriver driver;
        protected WebDriverWait wait;
        protected JObject testData;
        protected IJavaScriptExecutor executor;
        protected JObject testUser;
        protected JObject testUser2;
        protected JObject errorMessage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var option = new ChromeOptions();

            // Отключение "Браузером управляет автоматизированное ПО"
            option.AddAdditionalChromeOption("useAutomationExtension", false);
            option.AddExcludedArgument("enable-automation");
            
            driver = new ChromeDriver(@"C:\Tools\", option);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            executor = driver;

            var path = Utils.GetFilePathByFileName("testData.json");
            testData = JObject.Parse(File.ReadAllText(path));
            testUser = (JObject)testData["testUser"];
        }

        public static void WaitElementIsVisble(IWebDriver diver, By locator, int seconds = 5)
        {
            new WebDriverWait(diver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
        }
        
        public static void WaitElementIsClickable(IWebDriver diver, By locator, int seconds = 5)
        {
            new WebDriverWait(diver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        
        [OneTimeTearDown]
        public void OneTearDown()
        {
            driver.Quit();
        }
    }
}