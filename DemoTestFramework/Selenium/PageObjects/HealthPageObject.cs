using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class HealthPageObject : BasePage
{
    private WebDriver _driver;
    private const string healthPageNameh1 = "Товары для здоровья";    

    public HealthPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetHealthPageName => healthPageNameh1;
}