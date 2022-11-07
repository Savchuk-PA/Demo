using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class GardenPageObject : BasePage
{
    private WebDriver _driver;
    private const string gardenPageNameh1 = "Товары для дачи и сада";

    public GardenPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetGardenPageName => gardenPageNameh1;
}