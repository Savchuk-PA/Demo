using System;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Selenium;

public class Helpers : TestBase
{
    private static Random rnd = new Random();
    
    public static int GetRandomIntRange(int first, int second)
    {
         return rnd.Next(first, second);
    }
    
    public static string GetRandomEmail()
    {
        DateTime dateTime = DateTime.Now;
        return dateTime.Ticks.ToString() + "@gmail.com";
    }
    public static string GetDataToString()
    {
        DateTime dateTime = DateTime.Now;
        return dateTime.Ticks.ToString() + ".png";
    }

    public static void GetScreen(WebDriver driver)
    {
        Screenshot screenshot = driver.GetScreenshot();
        screenshot.SaveAsFile(@"C:\git2\DemoFramewrok\DemoTestFramework\Selenium\Screens\" + GetDataToString());
    }

    public static double ConvertPrice(string price) {
        string numericString = "";
        foreach (char c in price )
        {
            // Check for numeric characters (0-9), a negative sign, or leading or trailing spaces.
            if ((c >= '0' && c <= '9') || c == ',')
            {
                numericString = string.Concat(numericString, c);
            }
            else
            {
                continue;
            }
        }
        return (Convert.ToDouble(numericString));
    }
}