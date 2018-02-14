using EverNoteAutomation;
using NUnit.Framework;

namespace EverNoteTests
{
    [TestFixture]
    public class CreateNoteTests
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("georgi.pluralsight27@gmail.com").Continue().WithPassword("georgiana").Login();
        }

        [Test]
        public void CanCreateABasicNote()
        {
            NewNotePage.GoTo();
            NewNotePage.CreateNote("This is the test note title").WithContent("Hi, this is the content").Done();

           Assert.AreEqual(NotesPage.Title, "This is the test note title", "Title did not match new post.");
        }

        [TearDown]
        public void CleanUp()
        {
            //Delete the basic note added
            NotesPage.TrashNote("This is the test note title");
            
            Driver.Close();
        }

    }
}
