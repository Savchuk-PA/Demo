using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ChildrensProductsPageObject : BasePage
{
    private WebDriver _driver;
    private const string childrensProductssPageNameh1 = "Детские товары";
    public ChildrensProductsPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetChildrensProductsPageName => childrensProductssPageNameh1;
}