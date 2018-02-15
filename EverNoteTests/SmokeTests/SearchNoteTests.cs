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
            NewNotePage.GoTo();
            NewNotePage.CreateNote("This is search note title").WithContent("Hi, this is the content").Done();
        }

        [Test]
        public void SearchNote()
        {
            SearchPage.GoTo();
            SearchPage.SearchNote("This is search note title").SearchInNotebook();

            Assert.AreEqual(SearchPage.Title, "This is search note title", "Title did not match new note.");
        }

        [TearDown]
        public void CleanUp()
        {
            //delete the basic note created in the setup
            NotesPage.TrashNote("This is search note title");

            Driver.Close();
        }
    }
}
