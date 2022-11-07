using System.Threading;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class MainMenuPageObject : BasePage
{
    private WebDriver _driver;
    private IWebElement btnLogin => _driver.FindElement(By.XPath("//a[@href = '/#']"));
    private IWebElement nameUser => _driver.FindElement(By.XPath("//a[@data-test-id = 'button__user']"));
    private const string mainUrl = "https://kazanexpress.ru/";
    public MainMenuPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    public string GetMainUrl => mainUrl;

    public IWebElement GetElementBtnLogin()
    {
        return btnLogin;
    }

    [AllureStep("Клик на кнопку Вход")]
    public AuthorizationPageObject ClickloginButton()
    {
        WaitElementIsVisble(_driver, By.XPath("//a[@href = '/#']"));
        btnLogin.Click();
        return new AuthorizationPageObject(_driver);
    }

    [AllureStep("Обновление страницы")]
    public void Refresh()
    {
        _driver.Navigate().Refresh();
    }

    [AllureStep("Получение имени пользователя")]
    public string GetUserName()
    {
        WaitElementIsVisble(_driver, By.XPath("//a[@data-test-id = 'button__user']"));
        return nameUser.Text;
    }
}