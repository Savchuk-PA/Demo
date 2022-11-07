using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class BeautyPageObject : BasePage
{
    WebDriver _driver; 
    private const string beatuPageNameh1= "Товары для красоты";
    public BeautyPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    public string GetBeatuPageName
    {
        get { return beatuPageNameh1; }
        set { }
    }
}