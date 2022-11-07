using System.Threading;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class AuthorizationPageObject : BasePage
{
    private WebDriver _driver;
    private IWebElement _inputEmailOrPhone => _driver.FindElement(By.XPath("//input[@data-test-id = 'input__login']"));
    private IWebElement _inputPassword => _driver.FindElement(By.XPath("//input[@data-test-id = 'input__password']"));
    private IWebElement _signButton => _driver.FindElement(By.XPath("//button[@data-test-id = 'button__sign-in']"));
    private IWebElement _forgetPasswordButton => _driver.FindElement(By.XPath("//button[@data-test-id = 'button__sign-in']"));
    private IWebElement _registrationButton => _driver.FindElement(By.XPath("//button[@data-test-id = 'button__sign-up']"));
    private IWebElement _noAccountText => _driver.FindElement(By.XPath("//span[@data-test-id = 'text__footer']"));
    private IWebElement _signInTextInModal => _driver.FindElement(By.XPath("//h4[@data-test-id = 'text__name-modal-base']"));
    private IWebElement _buttonCloseModal => _driver.FindElement(By.XPath("//img[@data-test-id = 'button__close-modal']"));
    
    private IWebElement _dataError => _driver.FindElement(By.XPath("//div[@data-error = 'Минимум 8 символов']"));
    
    public void EnterEmailOrPhone(string emailOrPhone) => _inputEmailOrPhone.SendKeys(emailOrPhone);
    public void EnterPassword(string password) => _inputPassword.SendKeys(password);
    public void ClickSignIn() => _signButton.Click();
    public AuthorizationPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    [AllureStep("Заполнение формы авторизации")]
    public MainMenuPageObject Login(string login, string passsword)
    {
        WaitElementIsVisble(_driver, By.XPath("//input[@data-test-id = 'input__login']"));
        _inputEmailOrPhone.SendKeys(login);
        _inputPassword.SendKeys(passsword);
        _signButton.Click();
        Thread.Sleep(1000);

        return new MainMenuPageObject(_driver);
    }
    
    [AllureStep("Заполнение формы авторизации")]
    public AuthorizationPageObject FillOutTheFormAndSubmit(string login, string passsword)
    {
        WaitElementIsVisble(_driver, By.XPath("//input[@data-test-id = 'input__login']"));
        _inputEmailOrPhone.SendKeys(login);
        _inputPassword.SendKeys(passsword);
        _signButton.Click();
        
        return new AuthorizationPageObject(_driver);
    }

    

    [AllureStep("Получение информации об ошибке ввода пароля")]
    public string GetTextErrorPassword()
    {
       return _dataError.GetAttribute("data-error").ToString();
    }
    
    [AllureStep("Получение информации о видимости элементов")]
    public bool ElementIsVisible()
    {
        try
        {
            bool emailDisplayed = _inputEmailOrPhone.Displayed;
            bool passwordDisplayed = _inputPassword.Displayed;
            bool forgetPasswordButton = _forgetPasswordButton.Displayed;
            bool buttonCloseModal = _buttonCloseModal.Displayed;
            bool registrationButton = _registrationButton.Displayed;
            bool noAccountText = _noAccountText.Displayed;
            bool signInTextt = _signInTextInModal.Displayed;
            
            return true;
        }
        catch
        {
            return false;
        }
    }
}