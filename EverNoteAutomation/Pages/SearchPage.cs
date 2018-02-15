using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverNoteAutomation.Pages
{
    public class SearchPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.CssSelector(".focus-NotesView-Note-noteTitle.qa-title")).Text;
                return (title != null) ? title : String.Empty;
            }
        }

        public static void GoTo()
        {
            LeftNavigation.SearchNote.Select();
        }

        public static SearchCommand SearchNote(string title)
        {
            return new SearchCommand(title);
            
        }
    }

    public class SearchCommand
    {
        private string title;

        public SearchCommand(string title)
        {
            this.title = title;
        }
        public void SearchInNotebook()
        {
            var searchInput = Driver.Instance.FindElement(By.Id("gwt-debug-searchViewSearchBox"));
            searchInput.SendKeys(title);
            Driver.Wait(TimeSpan.FromSeconds(2));
            searchInput.SendKeys(Keys.Enter);
        }
            
    }
}
