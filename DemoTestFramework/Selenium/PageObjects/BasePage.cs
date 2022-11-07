using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Threading;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V103.Debugger;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class BasePage : TestBase
{
    private WebDriver _driver;
    
    public BasePage(WebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    // логотип
    [FindsBy(How = How.XPath, Using = "//a[@data-test-id = 'link__logo']")]
    public IWebElement Logo { get; set; }

    [AllureStep("Клик логотип")]
    public MainMenuPageObject ClickLogo()
    {   WaitElementIsVisble(_driver, By.XPath("//a[@data-test-id = 'link__logo']"));
        Logo.Click();
        return new MainMenuPageObject(_driver);
    }

    // Элементы строки поиска
    [FindsBy(How = How.XPath, Using = "//button[@data-test-id = 'button__search']")]
    public IWebElement SearchBtn { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//input[@data-test-id= 'input__search']")][CacheLookup] 
    public IWebElement InputSearch { get; set; }
    
    //h1 Заголовок страницы
    
    [FindsBy(How = How.XPath, Using = "//h1[@data-test-id = 'text__title']")]
    public IWebElement H1Title { get; set; }
    
    // получение заголовка страницы (h1) 
    [AllureStep("Получение имени страницы")]
    public string GetTextH1TitileInPage()
    {
        WaitElementIsVisble(_driver, By.XPath("//h1[@data-test-id = 'text__title']"));
        return H1Title.Text;
    }
    // Кнопка выбора сортировки товара
    [FindsBy(How = How.XPath, Using = "//div[@data-test-id = 'button__dropdown']")]
    public IWebElement SortButton { get; set; }

    [AllureStep("Клик на кнопку сортровки товара")]
    public void SortButtonClick()
    {
        WaitElementIsVisble(_driver,By.XPath("//div[@data-test-id = 'button__dropdown']"));
        SortButton.Click();
    }

    [FindsBy(How = How.XPath, Using = "//li[@data-test-id = 'list__item'][1]")]
    public IWebElement PopularSelect { get; set; }

    [AllureStep("Выбор парметра сортировки: Популярные")]
    public void PopularGoodsClick()
    {
        PopularSelect.Click();
    }
    
    [FindsBy(How = How.XPath, Using = "//li[@data-test-id = 'list__item'][2]")]
    public IWebElement СheaperGoods { get; set; }
    
    [AllureStep("Выбор парметра сортировки: Подешевле")]
    public void СheaperGoodsClick()
    {
        СheaperGoods.Click();
    }
    
    [FindsBy(How = How.XPath, Using = "//li[@data-test-id = 'list__item'][3]")]
    public IWebElement MoreExpensiveGoods { get; set; }
    
    
    [AllureStep("Выбор парметра сортировки: Подешевле")]
    public void MoreExpensiveGoodsClick()
    {
        MoreExpensiveGoods.Click();
    }
    
    [FindsBy(How = How.XPath, Using = "//li[@data-test-id = 'list__item'][4]")]
    public IWebElement HightRating { get; set; }
    
    [AllureStep("Выбор парметра сортировки: Высокий рейтинг")]
    public void HightRatingClick()
    {
        HightRating.Click();
    }
    
    [FindsBy(How = How.XPath, Using = "//li[@data-test-id = 'list__item'][5]")]
    public IWebElement ManyOrders { get; set; }
    
    [AllureStep("Выбор парметра сортировки: Много заказов")]
    public void ManyOrdersClick()
    {
        ManyOrders.Click();
    }
    
    [FindsBy(How = How.XPath, Using = "//li[@data-test-id = 'list__item'][6]")]
    public IWebElement AddedRecently { get; set; }
    
    [AllureStep("Выбор парметра сортировки: Добавлены недавно")]
    public void AddedRecentlyClick()
    {
        AddedRecently.Click();
    }
    //a[@data-test-id = 'button__cart']
    
    [FindsBy(How = How.XPath, Using = "//a[@data-test-id = 'button__cart']")]
    public IWebElement Cart { get; set; }

    public void CartButtonClick()
    {
        WaitElementIsVisble(_driver, By.XPath("//a[@data-test-id = 'button__cart']"));
        Cart.Click();
    }

    [FindsBy(How = How.XPath, Using = "//a[@data-test-id = 'button__wishes']")]
    public IWebElement FavoriteButton { get; set; }

    
    [AllureStep("Переход в раздел избраное")]
    public void FavoriteBtnClick()
    {
        WaitElementIsClickable(_driver, By.XPath("//a[@data-test-id = 'button__wishes']"));
        FavoriteButton.Click();
    }
    
    [AllureStep("Выбор критерия сортировки")]
    public void SelectSortInput(string nameSort)
    {
        WaitElementIsClickable(_driver, By.XPath("//div[@data-test-id = 'button__dropdown']"));
        SortButtonClick();
        if (nameSort == "Популярные")
        {
            PopularGoodsClick();
        }
        if (nameSort == "Подешевле")
        {
            СheaperGoodsClick();
        }
        if (nameSort == "Подороже")
        {
            MoreExpensiveGoodsClick();
        }
        if (nameSort == "Высокий рейтинг")
        {
            HightRatingClick();
        }
        if (nameSort == "Много заказов")
        {
            ManyOrdersClick();
        }

        if (nameSort == "Добавлены недавно")
        {
            AddedRecentlyClick();
        }
        
    }


    // Блок с промтоваром
    [FindsBy(How = How.XPath, Using = "//div[@class = 'carousel-offer content']")]
    public  IWebElement  Promo { get; set; }

    // элементы разделов: эелктроника, одежда и т.п
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-0']")] 
    public IWebElement ElectronicsButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-1']")]
    public IWebElement AppliancesButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-2']")]
    public IWebElement ClothingButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-3']")]
    public IWebElement ShoesButton{ get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-4']")]
    public IWebElement AccessoriesButton{ get; set; }

    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-5']")]
    public IWebElement BeautyButton{ get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-6']")]
    public IWebElement HealthButton{ get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-7']")]
    public IWebElement HouseholdsProductButton{ get; set; }
    
    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-8']")]
    public IWebElement ConstructionAndRepairButton{ get; set; }

    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-9']")]
    public IWebElement AutoProductsButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//li[@id = 'category-10']")]
    public IWebElement ChildrensProductsButton { get; set; }
    
    // Кнопка "Ещё" в майн бар, открывает доп список страницк
    [FindsBy(How = How.XPath, Using = "//div[@class = 'more']")]
    public IWebElement MoreList { get; set; }
    
    // Эелементы внутри списка "Ещё"
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Хобби и творчество']")]
    public IWebElement HobbyAndCreativityButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Товары для взрослых']")]
    public IWebElement ProductsForAdultsButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Спорт и отдых']")]
    public IWebElement SportButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Продукты питания']")]
    public IWebElement FoodButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Бытовая химия и личная гигиена']")]
    public IWebElement HouseholdСhemicalsButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Канцтовары']")]
    public IWebElement StationeryButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Зоотовары']")]
    public IWebElement PetSuppliesButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Книги']")]
    public IWebElement BookButton { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//span[text() = 'Дача, сад и огород']")]
    public IWebElement GardenButton { get; set; }
    
    
    [AllureStep("Открытие доп раздела 'Ещё' в майн бар")]
    public void ClickMore()
    {
        WaitElementIsVisble(_driver,By.XPath("//div[@class = 'more']"));
        MoreList.Click();
    }

    [AllureStep("Ввод в строку поиска")]
    public void InputSearchLine(string str)
    {
        WaitElementIsVisble(_driver,By.XPath("//input[@data-test-id = 'input__search']"));
        InputSearch.SendKeys(str);
        SearchBtn.Click();
        WaitElementIsVisble(_driver, By.XPath("//h2[@data-test-id = 'text__filter-name']"));
    }
    
    [AllureStep("Ввод с строку поиска")]
    public void ClickSearchBtn()
    {
        WaitElementIsVisble(_driver,By.XPath("//button[@data-test-id = 'button__search']"));
        SearchBtn.Click();
    }
    
    [AllureStep("Переход в раздел электроника")]
    public ElectronicsPageObject ClickElectronicBtn()
    {
        WaitElementIsVisble(_driver,By.XPath("//li[@id = 'category-0']"));
        ElectronicsButton.Click();
        Thread.Sleep(5000);

        return new ElectronicsPageObject(_driver);
    }

    [AllureStep("Переход в раздел Бытовая техника")]
    public AppliancesPageObject ClickApplianscesBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-1']"));
        AppliancesButton.Click();
        Thread.Sleep(5000);

        return new AppliancesPageObject(_driver);
    }

    [AllureStep("Переход в раздел Одежда")]
    public ClothingPageObject ClickClothingBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-2']"));
        ClothingButton.Click();

        return new ClothingPageObject(_driver);
    }
    
    [AllureStep("Переход в раздел Обувь")]
    public ShoesPageObject ClickShoesBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-3']"));
        ShoesButton.Click();

        return new ShoesPageObject(_driver);
    }
    
    [AllureStep("Переход в раздел Аксессуары")]
    public AccessoriesPageObject ClickAccessoriesBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-4']"));
        AccessoriesButton.Click();

        return new AccessoriesPageObject(_driver);
    }

    [AllureStep("Переход в раздел Красота")]
    public BeautyPageObject ClickBeautyBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-5']"));
        BeautyButton.Click();

        return new BeautyPageObject(_driver);
    }

    [AllureStep("Переход в раздел Здоровье")]
    public HealthPageObject ClickHealthBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-6']"));
        HealthButton.Click();

        return new HealthPageObject(_driver);
    }

    [AllureStep("Переход в раздел Товары для дома")]
    public HouseholdsProductsPageObject ClickHouseholdsProductsBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-7']"));
        HouseholdsProductButton.Click();

        return new HouseholdsProductsPageObject(_driver);
    }

    [AllureStep("Переход в раздел Строительство и ремонт")]
    public ConstructionAndRepair ClickConstructionAndRepairBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-8']"));
        ConstructionAndRepairButton.Click();
        
        return new ConstructionAndRepair(_driver);
    }

    [AllureStep("Переход в раздел Автотовары")]
    public AutoProductsPageObject ClickAutoProductsBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-9']"));
        AutoProductsButton.Click();

        return new AutoProductsPageObject(_driver);
    }

    [AllureStep("Переход в раздел Десткие товары")]
    public ChildrensProductsPageObject ClickChildrensProductsBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-10']"));
        ChildrensProductsButton.Click();

        return new ChildrensProductsPageObject(_driver);
    }

    [AllureStep("Переход в раздел Хобби и творчество")]
    public HobbyAndCreativityPageObject ClickHobbyAndCreativityBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-11']"));
        HobbyAndCreativityButton.Click();

        return new HobbyAndCreativityPageObject(_driver);
    }
    
    [AllureStep("Переход на станицу Товары для взрослых")]
    public ProductsForAdultsPageObject ProductsForAdultsClickBtn()
    {
        WaitElementIsVisble(_driver, By.XPath("//span[text() = 'Товары для взрослых']"));
        ProductsForAdultsButton.Click();

        return new ProductsForAdultsPageObject(_driver);
    }

    [AllureStep("Переход в раздел Спорт")]
    public SportPageObject SportClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-13']"));
        SportButton.Click();

        return new SportPageObject(_driver);
    }

    [AllureStep("Переход в раздел Еда")]
    public FoodPageObject FoodClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//span[text() = 'Продукты питания']"));
        FoodButton.Click();

        return new FoodPageObject(_driver);
    }

    [AllureStep("Переход в раздел Бытовая химия")]
    public HouseholdСhemicalsPageObject HouseholdСhemicalsClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-15']"));
        HouseholdСhemicalsButton.Click();

        return new HouseholdСhemicalsPageObject(_driver);
    }

    [AllureStep("Переход в раздел Канцелярские товары")]
    public StationeryPageObject StationeryClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-16']"));
        StationeryButton.Click();

        return new StationeryPageObject(_driver);
    }

    [AllureStep("Переход в раздел Зоотовары")]
    public PetSuppliesPageObject PetSuppliesClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-17']"));
        PetSuppliesButton.Click();

        return new PetSuppliesPageObject(_driver);
    }

    [AllureStep("Переход в раздел Книги")]
    public BookPageObject BookClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-18']"));
        BookButton.Click();

        return new BookPageObject(_driver);
    }

    [AllureStep("Переход в раздел Сад")]
    public GardenPageObject GardenClickBtn()
    {
        WaitElementIsClickable(_driver, By.XPath("//li[@id = 'category-19']"));
        GardenButton.Click();

        return new GardenPageObject(_driver);
    }

    [AllureStep("Проверка отображения промо товара")]
    public bool CheckPromoBlockProductIsVisible()
    {
        WaitElementIsVisble(_driver, By.XPath("//div[@class = 'carousel-offer content']"));
        var promoDisplayed = Promo.Displayed;
        return promoDisplayed;
    }
}