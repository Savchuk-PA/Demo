using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.Page;
using Selenium.PageObjects;
using SeleniumExtras.PageObjects;

namespace Selenium;

[TestFixture]
[AllureNUnit]
public class SearchTests : TestBase
{
    [SetUp]
    public void SetUp()
    {
        driver.Navigate().GoToUrl("https://kazanexpress.ru/");
    }

    [Test]
    [AllureTag("Поиск товара")]
    public void CheckSearchManufactureName()
    {
        string manufacturerName = "Xiaomi";
        manufacturerName.ToLower();
        
        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        PageFactory.InitElements(driver, mainMenu);
        mainMenu
            .InputSearchLine(manufacturerName);
        var listProduct = driver.FindElements(By.XPath("//div[@data-test-id = 'list__products']//a[@data-test-id = 'item__product-card']")).ToList();
        IWebElement cardItemInPageList = listProduct[Helpers.GetRandomIntRange(0, 47)];
        
        string textInElement = cardItemInPageList.Text;
        textInElement.ToLower();
        
        bool chekManufacturerInElement = textInElement.Contains(manufacturerName);
        
        Assert.IsTrue(chekManufacturerInElement);
    }

    [Test]
    [AllureTag("Проверка количества отображаемых карточек товара на странице, по поиску товара")]
    public void CheckCountCardsProductInPage()
    {
        const int item = 48;
        string manufacturerName = "Часы";
        
        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        PageFactory.InitElements(driver, mainMenu);
        mainMenu
            .InputSearchLine(manufacturerName);
        var listProduct = driver.FindElements(By.XPath("//div[@data-test-id = 'list__products']//a[@data-test-id = 'item__product-card']")).ToList();

        int countCardProduct = listProduct.Count;
        
        Assert.AreEqual(item, countCardProduct, $"Ожидалось {item}, получено {countCardProduct}");
    }





    [TearDown]
    public void TearDown()
    {
    }
}