using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class HouseholdСhemicalsPageObject : BasePage
{
    private WebDriver _driver; 
    private const string householdСhemicalsPageNameh1 = "Бытовая химия и средства личной гигиены";
    public HouseholdСhemicalsPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetHouseholdСhemicalsPageName => householdСhemicalsPageNameh1;
}