using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium;

[TestFixture]
[AllureNUnit]
public class LoginTests : TestBase
{

    [SetUp]
    public void SetUp()
    {
        driver.Navigate().GoToUrl("https://kazanexpress.ru/");
    }
    [TearDown]
    public void TearDown()
    { }

    [Test]
    [AllureTag("Вход под пользавтелем с валидными данными")]
    public void PositiveLoginUser()
    {
        testUser = (JObject)testData["testUser1"];

        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        PageFactory.InitElements(driver, mainMenu);
        mainMenu
            .ClickloginButton()
            .Login(testUser["login"].ToString(), testUser["password"].ToString())
            .Refresh();
        string user = mainMenu.GetUserName();

        Assert.AreEqual(testUser["name"].ToString(), user, "Имя пользователя не совпадает");
    }
    
    [Test]
    [AllureTag("Вход под пользователем с коротким паролем. Негативный тест")]
    public void NegativeLoginShrotPassword()
    {
        testUser2 = (JObject)testData["testUser2"];
        errorMessage = (JObject)testData["errorMesageAuthShortPassword"];

        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        PageFactory.InitElements(driver, mainMenu);
        
        var actualErrorMessage = mainMenu
            .ClickloginButton()
            .FillOutTheFormAndSubmit(testUser2["login"].ToString(), testUser2["password"].ToString())
            .GetTextErrorPassword();
        
        string expecctedErrorMessage = errorMessage["message"].ToString();

        Assert.AreEqual(actualErrorMessage, expecctedErrorMessage,
            $"Ожидалась ошибка {actualErrorMessage}, была получена ошибка {expecctedErrorMessage}");
    }

    [Test]
    [AllureTag("Проверка присутствия элементов в форме авторизации")]
    public void ChekElemntAuthFormIsVisible()
    {
        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        PageFactory.InitElements(driver, mainMenu);
        bool elements = mainMenu
            .ClickloginButton()
            .ElementIsVisible();
        Assert.True(elements);
    }
}