using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace EverNoteAutomation
{
    public class Driver
    {
        public static string BaseAddress
        {
            get
            {
                return "https://evernote.com";
            }
        }

        public static IWebDriver Instance { get; set; }
        public static void Initialize()
        {
            //Instance = new FirefoxDriver();
            Instance = new ChromeDriver();
            Instance.Manage().Cookies.DeleteAllCookies();
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)timeSpan.TotalSeconds * 1000);
        }
    }
}
