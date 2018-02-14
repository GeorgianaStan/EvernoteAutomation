using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EverNoteAutomation
{
    public class LoginPage
    {
        public static bool IsAt
        {
            get
            {
               return (Driver.Instance.FindElement(By.LinkText("Log in")).Text == "Log in") ? true : false;
            }
        }

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
            Driver.Instance.FindElement(By.LinkText("Log in")).Click();

        }

        public static ContinueCommand LoginAs(string userName)
        {
            return new ContinueCommand(userName);
        }
    }


    public class ContinueCommand
    {
        private string userName;
        
        public ContinueCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand Continue()
        {
            var userNameInput = Driver.Instance.FindElement(By.Id("username"));
            userNameInput.SendKeys(userName);

            var continueButton = Driver.Instance.FindElement(By.Id("loginButton"));
            continueButton.Click();

            return new LoginCommand();
        }
    }

    public class LoginCommand
    {
        private string password;

        public LoginCommand()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "password");
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var passwordInput = Driver.Instance.FindElement(By.Id("password"));
            passwordInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.Id("loginButton"));
            loginButton.Click();
        }
    }
}

