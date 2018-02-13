using EverNoteAutomation;
using NUnit.Framework;

namespace EverNoteTests
{
    [TestFixture]
    public class CreateNoteTests : EvernoteTest
    {
        [Test]
        public void CanCreateABasicNote()
        {
            NewNotePage.GoTo();
            NewNotePage.CreateNote("This is the test note title").WithContent("Hi, this is the content").Done();

           Assert.AreEqual(NotesPage.Title, "This is the test note title", "Title did not match new post.");
        }
    }
}
