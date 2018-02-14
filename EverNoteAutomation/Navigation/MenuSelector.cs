using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EverNoteAutomation
{
    public class MenuSelector
    {
        public static void Select(string menuId)
        {
            Driver.Wait(TimeSpan.FromSeconds(6));
            Driver.Instance.FindElement(By.Id(menuId)).Click();
            Driver.Wait(TimeSpan.FromSeconds(6));

            //var menu = Driver.Instance.FindElement(By.Id(menuId));
            //var waitMenu = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            //waitMenu.Until(ExpectedConditions.ElementToBeClickable(menu));
            //menu.Click();
            
        }
    }
}
