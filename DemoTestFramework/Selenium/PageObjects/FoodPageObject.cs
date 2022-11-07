using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class FoodPageObject : BasePage
{
    private WebDriver _driver;
    private const string foodPageNameh1 = "Продукты питания";

    public FoodPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    public string GetFoodPageName => foodPageNameh1;
}