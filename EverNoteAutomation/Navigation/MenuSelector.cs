using OpenQA.Selenium;
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
        }
    }
}
