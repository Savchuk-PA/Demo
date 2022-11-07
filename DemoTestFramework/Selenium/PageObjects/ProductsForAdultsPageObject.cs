using System;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.PageObjects;

public class ProductsForAdultsPageObject : BasePage
{
    private WebDriver _driver;
    private const string productsForAdultsPageNameh1 = "Товары для взрослых";
    public ProductsForAdultsPageObject(WebDriver driver) : base(driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//div[@data-test-id = 'block__adult-notification']")]
    public IWebElement BlockNotification{ get; set; }
    
    [FindsBy(How = How.XPath, Using = "//a[@href='/product/Prolongator-sprej-i-300180?SG=1176992']")]
    public IWebElement HidenItemCard{ get; set; }
    

    [FindsBy(How = How.XPath, Using = "//button[@class = 'noselect solid solid--red']")]
    public IWebElement NotificationButtonOn{ get; set; }
    public bool CheckHidenItemCard()
    {
        WaitElementIsVisble(_driver, By.XPath("//a[@href='/product/Prolongator-sprej-i-300180?SG=1176992']"));
        try
        {
            string res = HidenItemCard.GetAttribute("stop");
                if (res == "true")
                {
                return true;
                }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return false;
    }

    [AllureStep("Провека видимости информационного блока 18+")]
    public bool NotificationIsVisible()
    {
        WaitElementIsVisble(_driver, By.XPath("//div[@data-test-id = 'block__adult-notification']"));
        if(BlockNotification.Displayed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [AllureStep("Нажатие на кнопку 'Да, мне есть 18'")]
    public void NotificationButtonOkClick()
    {
        WaitElementIsClickable(_driver, By.XPath("//button[@class = 'noselect solid solid--red']"));
        NotificationButtonOn.Click();
        
    }

    public string GetProductsForAdultsPageName => productsForAdultsPageNameh1;
}