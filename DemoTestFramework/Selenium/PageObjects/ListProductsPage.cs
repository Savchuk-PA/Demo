using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ListProductsPage : BasePage
{
    private WebDriver _driver;
    
   
    public ListProductsPage(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    private List<IWebElement> listItemsCard => _driver.FindElements(By.XPath("//div[@data-test-id = 'list__products']//span[@data-test-id = 'text__price']")).ToList();

    private List<IWebElement> ListFavorite => _driver
        .FindElements(
            By.XPath("//div[@data-test-id = 'list__products']//button[@data-test-id = 'button__add-to-favorites']"))
        .ToList();

    public void AddToFavorite(int num)
    {
        Thread.Sleep(5000);
        ListFavorite[num].Click();
    }

    private List<IWebElement> listProductName => _driver.FindElements(By.XPath("//div[@data-test-id = 'list__products']//span[@data-test-id = 'text__product-name']")).ToList();
    public string GetProductName(int num)
    {
        Thread.Sleep(5000);
        return listProductName[num].Text;
    }
    public IWebElement GetListItemsCard(int num)
    {
        WaitElementIsVisble(_driver, By.XPath("//div[@data-test-id = 'list__products']//a[@data-test-id = 'item__product-card']"));
        return listItemsCard[num];
    }

    [FindsBy(How = How.XPath, Using = "//span[@data-test-id = 'text__price'][1]")]
    public IWebElement ItemPrice { get; set; }
    
    public double GetMinPriceListOfGoodsDouble()
    {
        string price = ItemPrice.Text;
        return Helpers.ConvertPrice(price);
    }
    
    [FindsBy(How = How.XPath, Using = "//input[@data-test-id = 'input__min-price']")]
    public IWebElement InputMinItemPrice { get; set; }
    
    [FindsBy(How = How.XPath, Using = "//input[@data-test-id = 'input__max-price']")]
    public IWebElement InputMaxItemPrice { get; set; }
    
    [AllureStep("Получение минимальной цены с плейсхолдера в строке ввода цены")]
    public double GetMinPriceInputPlaceHolderDouble()
    {
        string price = InputMinItemPrice.GetAttribute("placeholder");
        return Helpers.ConvertPrice(price);
    }
    
    [AllureStep("Получение максимальной цены с плейсхолдера в строке ввода цены")]
        public double GetMaxPriceInputPlaceHolderDouble()
    {
        string price = InputMaxItemPrice.GetAttribute("placeholder");
        return Helpers.ConvertPrice(price);
    }
        
    [AllureStep("Ввод минимальной цены")]
    public void InputMinPrice(string num)
    {
        WaitElementIsVisble(_driver, By.XPath("//input[@data-test-id = 'input__min-price']"));
        InputMinItemPrice.SendKeys(num);
        InputMaxItemPrice.SendKeys(Keys.Enter);
        Thread.Sleep(5000);
    }
}