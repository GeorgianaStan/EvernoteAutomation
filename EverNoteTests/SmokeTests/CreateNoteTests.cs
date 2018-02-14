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
        public List<string> noteTitles;

        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("georgi.pluralsight27@gmail.com").Continue().WithPassword("georgiana").Login();

            noteTitles = new List<string>();
        }

        [Test]
        public void CanCreateABasicNote()
        {
            NewNotePage.GoTo();
            NewNotePage.CreateNote("This is the test note title").WithContent("Hi, this is the content").Done();
            noteTitles.Add("This is the test note title");

            Assert.AreEqual(NotesPage.Title, "This is the test note title", "Title did not match new note.");
        }

        [Test]
        public void CanCreateABlankMeetingNote()
        {
            NewMeetingNotePage.GoTo();
            Driver.Instance.FindElement(By.CssSelector(".GJDCG5CBD.GJDCG5CFEB")).Click();
            noteTitles.Add("Untitled");

            Driver.Wait(TimeSpan.FromSeconds(2));

            Assert.AreEqual(NotesPage.Title, "Untitled", "Title did not match new note.");
            var noteContent=Driver.Instance.FindElement(By.CssSelector(".focus-NotesView-Note-snippet.qa-snippet")).Text.Trim();
            Assert.AreEqual("Date Time Location Participants Description Notes Next Steps", noteContent, "Content did not match new blank meeting note.");
        }

        [TearDown]
        public void CleanUp()
        {
            //Delete the basic note added
            foreach (var note in noteTitles)
            {
                NotesPage.TrashNote(note);
            }
            
            Driver.Close();
        }

    }
}
