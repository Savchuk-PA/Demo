using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private ChromeOptions option = new ChromeOptions();
        
        [SetUp]
        public void Setup()
        {
            // Отключение "Браузером управляет автоматизированное ПО"
            option.AddAdditionalChromeOption("useAutomationExtension", false);
            option.AddExcludedArgument("enable-automation");

            IWebDriver driver = new ChromeDriver(@"C:\Tools");
            driver.Navigate().GoToUrl("https://kazanexpress.ru");
        }
        
        [OneTimeTearDown]
        public void OneTearDown()
        {
            driver.Quit();
        }
    }
}