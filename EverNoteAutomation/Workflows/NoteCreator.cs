using EverNoteAutomation.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverNoteAutomation
{
    public class NoteCreator
    {
        public static string PreviousTitle { get; set; }
        public static string PreviousContent { get; set; }

                
        public static void CreateNote()
        {
            NewNotePage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousContent = CreateContent();

            NewNotePage.CreateNote(PreviousTitle).WithContent(PreviousContent).Done();
        }

        public static void CreateBlankMeetingNote()
        {
            NewMeetingNotePage.GoTo();
            NewMeetingNotePage.CreateAnBlankMeetingNote();
            PreviousTitle = Driver.Instance.FindElement(By.CssSelector(".focus-NotesView-Note-noteTitle.qa-title")).Text;
        }

        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }

        private static string CreateContent()
        {
            return CreateRandomString() + ", content";
        }

        private static string CreateRandomString()
        {
            var strBuilder = new StringBuilder();

            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i=0; i< cycles; i++)
            {
                strBuilder.Append(Words[random.Next(Words.Length)]);
                strBuilder.Append(" ");
                strBuilder.Append(Articles[random.Next(Articles.Length)]);
                strBuilder.Append(" ");
                strBuilder.Append(Words[random.Next(Words.Length)]);
                strBuilder.Append(" ");
            }
            return strBuilder.ToString();
        }

        private static string[] Words = new[]
        {
            "boy", "cat", "dog", "rabbit", "baseball", "throw", "find", "scary",
            "mustard"
        };

        private static string[] Articles = new[]
        {
            "the", "an", "and", "a", "of", "to", "it", "as"
        };
    }
}
