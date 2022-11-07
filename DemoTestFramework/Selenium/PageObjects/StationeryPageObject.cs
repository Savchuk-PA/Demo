using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class StationeryPageObject : BasePage
{
    private WebDriver _driver;
    private const string stationeryPageNameh1 = "Канцтовары";

    public StationeryPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetStationeryPageName => stationeryPageNameh1;
}