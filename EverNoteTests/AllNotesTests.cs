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
            NoteCreator.CreateNote();

            //Go to Notes, get new note count
            LeftNavigation.Notes.Select();
            Assert.AreEqual(NotesPage.PreviousNoteCount + 1, NotesPage.CurrentNoteCount, "Count of notes did not increase");

            //Check for added note
            Assert.IsTrue(NotesPage.DoesNoteExistWithTitle(NoteCreator.PreviousTitle));

            //Trash note (clean up) 
            NotesPage.TrashNote(NoteCreator.PreviousTitle);
            Assert.AreEqual(NotesPage.PreviousNoteCount, NotesPage.CurrentNoteCount, "Coundn't trah note");
        }
    }
}
