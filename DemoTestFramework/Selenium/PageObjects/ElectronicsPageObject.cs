using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ElectronicsPageObject : BasePage
{
    private const string electronicsPageNameh1 = "Электроника";
    
    private WebDriver _driver;


    public ElectronicsPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    

    public string GetElectronicsPageName()
    {
        return electronicsPageNameh1;
    }

    public void ClicSearch()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickSearchBtn();
    }

}