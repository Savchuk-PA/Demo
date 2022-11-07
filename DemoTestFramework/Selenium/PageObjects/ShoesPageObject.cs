using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.CSS;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ShoesPageObject : BasePage
{
    WebDriver _driver;
    private const string shoesPageName = "Обувь";

    public ShoesPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    public string GetShoesPageName
    {
        get { return shoesPageName; }
        set { }
    }

    public void test()
    {
        SelectorList select = new SelectorList();
    }

}