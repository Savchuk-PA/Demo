using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class AccessoriesPageObject : BasePage
{
    
    WebDriver _driver;
    private const string accessoriesPageName = "Аксессуары";

    public AccessoriesPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    public string GetAccessoriesPageName => accessoriesPageName;
}