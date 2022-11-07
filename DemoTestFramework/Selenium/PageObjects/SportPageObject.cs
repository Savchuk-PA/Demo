using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class SportPageObject : BasePage
{
    private WebDriver _driver;
    private const string getSportPageNameh1 = "Товары для спорта и отдыха";
    public SportPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    public string GetSportPageName => getSportPageNameh1;
}