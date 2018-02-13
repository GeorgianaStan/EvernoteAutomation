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
    public class NoteTest : EvernoteTest
    {
        [Test]
        public void CanEditAnExistingNote()
        {
            NotesPage.GoTo();
            NotesPage.SelectNote("Sample Note");

            Driver.Wait(TimeSpan.FromSeconds(1));

            Assert.IsTrue(NewNotePage.IsInUpgradeMode(), "Wasn't in upgrade mode");
            Assert.AreEqual("Sample Note", NotesPage.Title, "Title din not match");
        }
    }
}
