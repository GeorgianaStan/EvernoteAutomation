using EverNoteAutomation;
using NUnit.Framework;

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
    }
}
