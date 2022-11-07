using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class HobbyAndCreativityPageObject : BasePage
{
    private WebDriver _driver;
    private const string hobbyAndCreativityPageNameh1 = "Товары для хобби и творчества";
    public HobbyAndCreativityPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetHobbyAndCreativityPageName => hobbyAndCreativityPageNameh1;
}