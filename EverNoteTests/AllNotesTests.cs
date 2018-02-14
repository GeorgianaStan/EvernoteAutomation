using EverNoteAutomation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverNoteTests
{
    [TestFixture]
    public class AllNotesTests : EvernoteTest
    {
        [Test]
        public void AddedNotesShowUp()
        {
            //Go to notes, get notes count, store
            LeftNavigation.Notes.Select();
            NotesPage.StoreCount();

            //Add a new note
            NewNotePage.GoTo();
            NewNotePage.CreateNote("Added notes show up, title")
                       .WithContent("Added notes show up, content")
                       .Done();

            //Go to Notes, get new note count
            LeftNavigation.Notes.Select();
            Assert.AreEqual(NotesPage.PreviousNoteCount + 1, NotesPage.CurrentNoteCount, "Count of notes did not increase");

            //Check for added note
            Assert.IsTrue(NotesPage.DoesNoteExistWithTitle("Added notes show up, title"));

            //Trash note (clean up) 
            NotesPage.TrashNote("Added notes show up, title");
            Assert.AreEqual(NotesPage.PreviousNoteCount, NotesPage.CurrentNoteCount, "Coundn't trah note");
        }
    }
}
