using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class BookPageObject : BasePage
{
    private WebDriver _driver;
    private const string bookPageNameh1 = "Книги";

    public BookPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetBookPageName => bookPageNameh1;
}