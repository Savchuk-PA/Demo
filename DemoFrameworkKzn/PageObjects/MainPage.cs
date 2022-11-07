using OpenQA.Selenium;

namespace PageObjects
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(BasePage.driver)
        {
        }

        private IWebElement btnLogin => driver.FindElement(By.XPath("//a[@ href =  '/#']"));

        public void ClickLogin() => btnLogin.Click();
        
        

    }
    
}