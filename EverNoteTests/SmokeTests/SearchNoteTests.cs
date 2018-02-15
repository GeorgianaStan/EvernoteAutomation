using EverNoteAutomation;
using EverNoteAutomation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EverNoteTests.SmokeTests
{
    [TestFixture]
    public class SearchNoteTests
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("georgi.pluralsight27@gmail.com").Continue().WithPassword("georgiana").Login();

            //create a basic note
            //NewNotePage.GoTo();
            //NewNotePage.CreateNote("This is search note title").WithContent("Hi, this is the content").Done();
            NoteCreator.CreateNote();
        }

        [Test]
        public void SearchNote()
        {
            SearchPage.GoTo();
            SearchPage.SearchNote(NoteCreator.PreviousTitle).SearchInNotebook();
                //("This is search note title").SearchInNotebook();

            Assert.AreEqual(SearchPage.Title, NoteCreator.PreviousTitle, "Title did not match new note.");
        }

        [TearDown]
        public void CleanUp()
        {
            //delete the basic note created in the setup
            NotesPage.TrashNote(NoteCreator.PreviousTitle);

            Driver.Close();
        }
    }
}
