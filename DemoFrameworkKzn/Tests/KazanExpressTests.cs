using OpenQA.Selenium;
using PageObjects;


namespace Tests;

public class KazanExpressTests
{
   
   public class LoginTests : BaseTest
   {
      [Test]
      public void NegativeLogin()
      {
         MainPage main = new MainPage(driver);
         main.ClickLogin();
         Thread.Sleep(5000);
      }
      
      [Test]
      public void test()
      {
         driver.Navigate().GoToUrl("https://kazanexpress.ru/");
         
         Thread.Sleep(5000);
         
      }
   }
}