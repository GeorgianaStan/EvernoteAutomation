using EverNoteAutomation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EverNoteTests
{
    [TestFixture]
    public class NoteTest 
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("georgi.pluralsight27@gmail.com").Continue().WithPassword("georgiana").Login();

            //create a basic note
            NewNotePage.GoTo();
            NewNotePage.CreateNote("This is a basic note title").WithContent("Hi, this is the content").Done();
        }

       
        [Test]
        public void CanEditAnExistingNote()
        {
            NotesPage.GoTo();
            NotesPage.SelectNote("This is a basic note title");

            Driver.Wait(TimeSpan.FromSeconds(1));

            Assert.IsTrue(NewNotePage.IsInUpgradeMode(), "Wasn't in upgrade mode");
            Assert.AreEqual("This is a basic note title", NotesPage.Title, "Title din not match");
        }

        [TearDown]
        public void CleanUp()
        {
            //delete the basic note created in the setup
            NotesPage.TrashNote("This is a basic note title");
            
            Driver.Close();
        }
    }
}
