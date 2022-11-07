using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ConstructionAndRepair : BasePage
{
    private WebDriver _driver;
    private const string constructionAndRepairPageNameh1 = "Товары для строительства и ремонта";

    public ConstructionAndRepair(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetConstructionAndRepairPageName => constructionAndRepairPageNameh1;
}