using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class PetSuppliesPageObject : BasePage
{
    private WebDriver _driver;
    private const string petSuppliesPageNameh1 = "Зоотовары";

    public PetSuppliesPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetPetSuppliesPageName => petSuppliesPageNameh1;
}