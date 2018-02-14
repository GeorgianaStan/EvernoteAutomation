using EverNoteAutomation;
using NUnit.Framework;
using OpenQA.Selenium;

namespace EverNoteTests
{
    [TestFixture]
    public class LoginTest: EvernoteTest
    {
        [Test]
        public void CanLogin()
        {
            Assert.IsTrue(NotesPage.IsAt, "Fail to login");
        }

        [Test]
        public void CanLogout()
        {
            LeftNavigation.Account.Select();
            Driver.Instance.FindElement(By.Id("gwt-debug-AccountMenu-logout")).Click();

            Assert.IsTrue(LoginPage.IsAt, "Fail to logout");
        }
    }
}
