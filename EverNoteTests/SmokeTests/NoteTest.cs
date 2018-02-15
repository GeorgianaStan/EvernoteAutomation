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
            NoteCreator.CreateNote();
        }

       
        [Test]
        public void CanEditAnExistingNote()
        {
            NotesPage.GoTo();
            NotesPage.SelectNote(NoteCreator.PreviousTitle);

            Driver.Wait(TimeSpan.FromSeconds(1));

            Assert.IsTrue(NewNotePage.IsInUpgradeMode(), "Wasn't in upgrade mode");
            Assert.AreEqual(NoteCreator.PreviousTitle, NotesPage.Title, "Title din not match");
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
