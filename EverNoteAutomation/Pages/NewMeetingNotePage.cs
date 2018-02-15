using OpenQA.Selenium;
using System;

namespace EverNoteAutomation.Pages
{
    public class NewMeetingNotePage
    {
        public static void GoTo()
        {
            LeftNavigation.NewMeetingNote.Select();
        }

        public static void CreateAnBlankMeetingNote()
        {
            Driver.Instance.FindElement(By.CssSelector(".GJDCG5CBD.GJDCG5CFEB")).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
        }
    }
}
