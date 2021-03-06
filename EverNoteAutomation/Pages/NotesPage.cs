﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace EverNoteAutomation
{
    public class NotesPage
    {
        private static int lastCount;

        public static string Title
        {
            get
            {
                IJavaScriptExecutor ijse = (IJavaScriptExecutor)Driver.Instance;
                ijse.ExecuteScript("document.getElementById('gwt-debug-NoteTitleView-label').setAttribute('style', 'display:visible')");
                var title = Driver.Instance.FindElement(By.Id("gwt-debug-NoteTitleView-label")).Text;
                return (title!= null) ? title : String.Empty;
            }
        }

        public static void StoreCount()
        {
            lastCount = GetNoteCount();
        }

        public static void TrashNote(string title)
        {
            Driver.Wait(TimeSpan.FromSeconds(6));
            var notes = Driver.Instance.FindElements(By.CssSelector(".focus-NotesView-Note-noteTitle.qa-title"));
            var noteTileSelected = notes.Where(t => t.Text == title).FirstOrDefault();

            IJavaScriptExecutor ijse = (IJavaScriptExecutor)Driver.Instance;
            ijse.ExecuteScript("arguments[0].scrollIntoView(true);", noteTileSelected);

            Driver.Wait(TimeSpan.FromSeconds(5));

            noteTileSelected.Click();
            Driver.Instance.FindElement(By.Id("gwt-debug-NoteAttributes-trashButton")).Click();
            Driver.Instance.FindElement(By.Id("gwt-debug-ConfirmationDialog-confirm")).Click();

            Driver.Wait(TimeSpan.FromSeconds(2));

        }

        private static int GetNoteCount()
        {
            var countText = Driver.Instance.FindElement(By.CssSelector(".focus-NotesView-Subheader-NotesOverview.qa-notesCount")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesNoteExistWithTitle(string title)
        {
            Driver.Wait(TimeSpan.FromSeconds(6));
            var notes = Driver.Instance.FindElements(By.CssSelector(".focus-NotesView-Note-noteTitle.qa-title"));
            var noteTile = notes.Where(t => t.Text == title).FirstOrDefault();

            IJavaScriptExecutor ijse = (IJavaScriptExecutor)Driver.Instance;
            ijse.ExecuteScript("arguments[0].scrollIntoView(true);", noteTile);
            return (noteTile != null) ? true : false;
        }

        public static bool IsAt
        {
            get
            {
                var inboxNotebook = Driver.Instance.FindElement(By.Id("gwt-debug-NotebookSelectMenu-notebookName"));
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
                wait.Until(d => inboxNotebook.Displayed && inboxNotebook.Enabled && inboxNotebook.Text == "<Inbox>");
                return (inboxNotebook.Text == "<Inbox>") ? true : false;
            }
        }

        public static int PreviousNoteCount
        {
            get { return lastCount; }
        }

        public static int CurrentNoteCount
        {
            get
            {
                return GetNoteCount();
            }
        }

        public static void SelectNote(string titleNote)
        {
            Driver.Wait(TimeSpan.FromSeconds(6));
            var notes = Driver.Instance.FindElements(By.CssSelector(".focus-NotesView-Note-noteTitle.qa-title"));
            var noteTileSelected = notes.Where(t => t.Text == titleNote).FirstOrDefault();

            IJavaScriptExecutor ijse = (IJavaScriptExecutor)Driver.Instance;
            ijse.ExecuteScript("arguments[0].scrollIntoView(true);", noteTileSelected);
            
            Driver.Wait(TimeSpan.FromSeconds(5));

            noteTileSelected.Click();
        }

        public static void GoTo()
        {
            LeftNavigation.Notes.Select();
        }
    }
}
