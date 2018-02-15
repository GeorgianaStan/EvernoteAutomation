using EverNoteAutomation;
using EverNoteAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

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
            NoteCreator.CreateNote();
            Assert.AreEqual(NotesPage.Title, NoteCreator.PreviousTitle, "Title did not match new note.");
        }

        [Test]
        public void CanCreateABlankMeetingNote()
        {
            NoteCreator.CreateBlankMeetingNote();

            Assert.AreEqual(NotesPage.Title, NoteCreator.PreviousTitle, "Title did not match new note.");
            var noteContent=Driver.Instance.FindElement(By.CssSelector(".focus-NotesView-Note-snippet.qa-snippet")).Text.Trim();
            Assert.AreEqual("Date Time Location Participants Description Notes Next Steps", noteContent, "Content did not match new blank meeting note.");
        }

        [TearDown]
        public void CleanUp()
        {
            //Delete the note added
            NotesPage.TrashNote(NoteCreator.PreviousTitle);
            
            Driver.Close();
        }

    }
}
