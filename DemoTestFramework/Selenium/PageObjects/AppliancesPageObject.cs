using System.Security.AccessControl;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;


public class AppliancesPageObject : BasePage
{
    private const string appliancesPageName = "Бытовая техника";
    
    private WebDriver _driver;
    
    public AppliancesPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        
    }

    public string GetAppliancesPageName()
    {
        return appliancesPageName;
    }
}