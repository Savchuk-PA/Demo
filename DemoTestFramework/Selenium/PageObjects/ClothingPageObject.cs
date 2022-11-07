using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ClothingPageObject : BasePage
{
    private WebDriver _driver;
    private const string clothinPageNameh1 = "Одежда";
    
    public ClothingPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    public string GetClothingPageName()
    {
        return clothinPageNameh1;
    }
}