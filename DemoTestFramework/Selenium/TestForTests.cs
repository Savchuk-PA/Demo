using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.SystemInfo;
using Selenium.PageObjects;
using SeleniumExtras.PageObjects;
using Size = System.Drawing.Size;

namespace Selenium;

[TestFixture]
[AllureNUnit]
public class TestForTests : TestBase
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
    [AllureTag("Клик на логотип, логотип возвращает на главную страницу")]
    public void LogoNavigateTest()
    {
        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        mainMenu
            .ClickAccessoriesBtn()
            .ClickLogo();
        string actualUrl = driver.Url;
        string expectedMainUrl = mainMenu.GetMainUrl;
        
        Assert.AreEqual(expectedMainUrl, actualUrl, $"Ожидалось {expectedMainUrl}, получено {actualUrl}");
    }

    [Test]
    [AllureTag("Проверка отображения блока с подтверждением возраста 18+")]
    public void CheckConfirmBlock18ageInTheAdultPage()
    {
        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        mainMenu.ClickMore();
        mainMenu.ProductsForAdultsClickBtn();
        ProductsForAdultsPageObject adult = new ProductsForAdultsPageObject(driver);
        bool resultVisible = adult.NotificationIsVisible();
        Assert.IsTrue(resultVisible);
    }
    
    [Test]
    [AllureTag("Проверка сокрытия картинки товаров 18+")]
    public void CheckHideCardItemForAdult()
    {
        MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
        mainMenu.ClickMore();
        mainMenu.ProductsForAdultsClickBtn();
        ProductsForAdultsPageObject adult = new ProductsForAdultsPageObject(driver);
        bool itemHide = adult.CheckHidenItemCard();
        Assert.IsTrue(itemHide);
    }

    [Test]
    [AllureTag("Отображение блока с промотоваром")]
    public void ChekBlockPromoProduct()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickElectronicBtn();
        bool res = basePage.CheckPromoBlockProductIsVisible();
        Assert.IsTrue(res);
    }
    
    [Test]
    [AllureTag("Проверка сортировки")]
    public void ChekSortGoodsProduct()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickShoesBtn();
        basePage.SelectSortInput("Подешевле");
        ListProductsPage listProducts = new ListProductsPage(driver);
        IWebElement first = listProducts.GetListItemsCard(0);
        double fisrtProduct = Helpers.ConvertPrice(first.Text);
        IWebElement last = listProducts.GetListItemsCard(47);
        double lastProduct = Helpers.ConvertPrice(last.Text);
        bool res = fisrtProduct < lastProduct;
        Assert.IsTrue(res);
    }
    
    [Test]
    [AllureTag("Проверка соотвествия минимальной цены товара, с автоматически введенной стоимостью товара")]
    public void CheckRangePrice()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickShoesBtn();
        basePage.SelectSortInput("Подешевле");
        ListProductsPage listProducts = new ListProductsPage(driver);
        double minprice = listProducts.GetMinPriceListOfGoodsDouble();
        double minPriceInput = listProducts.GetMinPriceInputPlaceHolderDouble();
        bool res = minprice >= minPriceInput;
        Assert.IsTrue(res);
    }
    
    // тест работает правильно, просто сортировка отрабатывает некорректно
    [Test]
    [AllureTag("Проверка соотвествия минимальной цены товара в поле ввода минимальной цены, и первого отображаемого товара")]
    public void CheckSortMinPriceInINputPrice25ProcentFromMaxPrice()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickShoesBtn();
        basePage.SelectSortInput("Подешевле");
        ListProductsPage listProducts = new ListProductsPage(driver);
        double maxPrice = listProducts.GetMaxPriceInputPlaceHolderDouble();
        string minPriceForInput = Convert.ToString((maxPrice / 4.0));
        listProducts.InputMinPrice(minPriceForInput);
        
        var listProduct2 = driver.FindElements(By.XPath("//div[@data-test-id = 'list__products']//a[@data-test-id = 'item__product-card']//span[@data-test-id = 'text__price']")).ToList();
        IWebElement cardItemInPageList = listProduct2[1];
        double minPriceCard = Helpers.ConvertPrice(cardItemInPageList.Text);
        double minPrice = Helpers.ConvertPrice(minPriceForInput);
        bool res = minPrice <= minPriceCard;
        Assert.IsTrue(res);
    }
    
    [Test]
    [AllureTag("Проверка сортировки по убыванию")]
    public void CheckSortPriceDown()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickShoesBtn();
        basePage.SelectSortInput("Подороже");
        ListProductsPage listProducts = new ListProductsPage(driver);
        IWebElement first = listProducts.GetListItemsCard(0);
        double fisrtProduct = Helpers.ConvertPrice(first.Text);
        IWebElement last = listProducts.GetListItemsCard(47);
        double lastProduct = Helpers.ConvertPrice(last.Text);
        bool res = fisrtProduct > lastProduct;
        Assert.IsTrue(res);
    }
    
    [Test]
    [AllureTag("Добавление в избраное")]
    public void AddToFavorites()
    {
        BasePage basePage = new BasePage(driver);
        basePage.ClickShoesBtn();
        ListProductsPage listProducts = new ListProductsPage(driver);
        int rnd = Helpers.GetRandomIntRange(0, 47);
        string expected = listProducts.GetProductName(rnd);
        listProducts.AddToFavorite(rnd);
        basePage.FavoriteBtnClick();
        Helpers.GetScreen(driver);
        string actual = listProducts.GetProductName(0);
        Assert.AreEqual(expected, actual, $"Ожидалось {actual}, получено {expected}");
    }
    
    [Test]
    [TestCase(800, 600)]
    [TestCase( 300, 600)]
    [TestCase(740, 1280)]
    public void ScreenFooter(int height, int weight)
    {
        driver.Manage().Window.Size = new Size(height, weight);
        var element = driver.FindElement(By.XPath("//a[@href = 'https://legal.kazanexpress.ru/privacy-policy.html']"));
        executor.ExecuteScript("arguments[0].scrollIntoView(true);",element);
        Helpers.GetScreen(driver);
    }
}
