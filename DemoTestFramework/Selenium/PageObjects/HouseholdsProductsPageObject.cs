using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class HouseholdsProductsPageObject : BasePage
{
    private WebDriver _driver; 
    private const string householdsProductsPageNameh1 = "Товары для дома"; 

    public HouseholdsProductsPageObject(WebDriver driver) : base (driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetHouseholdsProductsPageName => householdsProductsPageNameh1;
}