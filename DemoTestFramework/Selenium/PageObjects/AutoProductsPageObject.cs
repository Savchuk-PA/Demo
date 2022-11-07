using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class AutoProductsPageObject : BasePage
{
    private WebDriver _driver;
    private const string autoProductsPageNameh1 = "Автотовары";

    public AutoProductsPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string autoProductsPageName => autoProductsPageNameh1;
}