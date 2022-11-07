using System;
using System.Threading;
using Allure.Commons;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.PageObjects;
using SeleniumExtras.PageObjects;

namespace Selenium;

[TestFixture]
[AllureNUnit]
public class CheckNameSectionPageTests : TestBase
{
    private JObject testUser;
    
    
    [SetUp]
    public void SetUp()
    {
        driver.Navigate().GoToUrl("https://kazanexpress.ru/");
    }
    
    [TearDown]
    public void TearDown()
    {
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Электроника")]
    public void CheckNameSectionElectronicsOfTheSite() 
    {
        BasePage basedPage = new BasePage(driver);
        
        string actualH1text = basedPage
            .ClickElectronicBtn()
            .GetTextH1TitileInPage();
        
        ElectronicsPageObject electronics = new ElectronicsPageObject(driver);

        string expectedH1text = electronics.GetElectronicsPageName();
        Assert.AreEqual(expectedH1text, actualH1text, $"Ожидалось {expectedH1text}, получено {actualH1text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Бытовая техника")]
    public void CheckSectionAppliancesOfTheSite() 
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickApplianscesBtn()
            .GetTextH1TitileInPage();
        
        AppliancesPageObject appliances = new AppliancesPageObject(driver);
        string expectedH1text = appliances.GetAppliancesPageName();
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Одежда")]
    public void CheckSectionClothingOfTheSite() 
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickClothingBtn()
            .GetTextH1TitileInPage();

        ClothingPageObject clothing = new ClothingPageObject(driver);
        string expectedH1text = clothing.GetClothingPageName();
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }

    [Test]
    [AllureTag("Проверка названия раздела Обувь")]
    public void CheckSectionShoesOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickShoesBtn()
            .GetTextH1TitileInPage();

        ShoesPageObject shoes = new ShoesPageObject(driver);
        string expectedH1text = shoes.GetShoesPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Аксессуары")]
    public void CheckSectionAccessoriesOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickAccessoriesBtn()
            .GetTextH1TitileInPage();

        AccessoriesPageObject accessories = new AccessoriesPageObject(driver);
        string expectedH1text = accessories.GetAccessoriesPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Красота")]
    public void CheckSectionBeautyOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickBeautyBtn()
            .GetTextH1TitileInPage();

        BeautyPageObject beauty = new BeautyPageObject(driver);
        string expectedH1text = beauty.GetBeatuPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Здоровье")]
    public void CheckSectionHealthOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickHealthBtn()
            .GetTextH1TitileInPage();

        HealthPageObject health = new HealthPageObject(driver);
        string expectedH1text = health.GetHealthPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Товары для дома")]
    public void CheckSectionHouseholdsProductsOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickHouseholdsProductsBtn()
            .GetTextH1TitileInPage();

        HouseholdsProductsPageObject householdsProducts = new HouseholdsProductsPageObject(driver);
        string expectedH1text = householdsProducts.GetHouseholdsProductsPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Товары для строительства и ремонта")]
    public void CheckSectionConstructionAndRepairOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickConstructionAndRepairBtn()
            .GetTextH1TitileInPage();

        ConstructionAndRepair constr = new ConstructionAndRepair(driver);
        string expectedH1text = constr.GetConstructionAndRepairPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Автотовары")]
    public void CheckSectionAutoProductsOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickAutoProductsBtn()
            .GetTextH1TitileInPage();

        AutoProductsPageObject auto = new AutoProductsPageObject(driver);
        string expectedH1text = auto.autoProductsPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Детские товары")]
    public void CheckSectionChildrensProductsOfTheSite()
    {
        BasePage basedPage = new BasePage(driver);
        string actualH1Text = basedPage
            .ClickChildrensProductsBtn()
            .GetTextH1TitileInPage();

        ChildrensProductsPageObject childrens = new ChildrensProductsPageObject(driver);
        string expectedH1text = childrens.GetChildrensProductsPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Товары для хобби и творчества")]
    public void CheckSectionHobbyAndCreativityOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.HobbyAndCreativityButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        HobbyAndCreativityPageObject hobby = new HobbyAndCreativityPageObject(driver);
        string expectedH1text = hobby.GetHobbyAndCreativityPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Товары для взрослых")]
    public void CheckSectionProductsForAdultsOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.ProductsForAdultsButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        ProductsForAdultsPageObject adult = new ProductsForAdultsPageObject(driver);
        string expectedH1text = adult.GetProductsForAdultsPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Товары для спорта и отдыха")]
    public void CheckSectionSportOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.SportButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        SportPageObject sport = new SportPageObject(driver);
        string expectedH1text = sport.GetSportPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Продукты питания")]
    public void CheckSectionFoodOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.FoodButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        FoodPageObject food = new FoodPageObject(driver);
        string expectedH1text = food.GetFoodPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Бытовая химия и личная гигиена")]
    public void CheckSectionHouseholdСhemicalsOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.HouseholdСhemicalsButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        HouseholdСhemicalsPageObject houseChemical = new HouseholdСhemicalsPageObject(driver);
        string expectedH1text = houseChemical.GetHouseholdСhemicalsPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Канцтовары")]
    public void CheckSectionStationeryOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.StationeryButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        StationeryPageObject stationery = new StationeryPageObject(driver);
        string expectedH1text = stationery.GetStationeryPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Зоотовары")]
    public void CheckSectionPetSuppliesOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.PetSuppliesButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        PetSuppliesPageObject pet = new PetSuppliesPageObject(driver);
        string expectedH1text = pet.GetPetSuppliesPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Книги")]
    public void CheckSectionBookOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.BookButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        BookPageObject book = new BookPageObject(driver);
        string expectedH1text = book.GetBookPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
    
    [Test]
    [AllureTag("Проверка названия раздела Книги")]
    public void CheckSectionGardenOfTheSite()
    {
        BasePage basePage = new BasePage(driver);
        WaitElementIsClickable(driver, By.XPath("//div[@class = 'more']"));
        basePage.MoreList.Click();
        basePage.GardenButton.Click();
        string actualH1Text = basePage.GetTextH1TitileInPage();
        GardenPageObject garden = new GardenPageObject(driver);
        string expectedH1text = garden.GetGardenPageName;
        Assert.AreEqual(expectedH1text, actualH1Text, $"Ожидалось {expectedH1text}, получено {actualH1Text}");
    }
}