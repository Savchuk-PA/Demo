using OpenQA.Selenium;

namespace PageObjects
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
           driver = webDriver;
        }
    }
}