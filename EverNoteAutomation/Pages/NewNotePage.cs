using OpenQA.Selenium;
using System;

namespace EverNoteAutomation
{
    public class NewNotePage
    {
        public static bool IsInUpgradeMode()
        {
            var upgradeButton = Driver.Instance.FindElement(By.CssSelector(".GJDCG5CENB.GJDCG5CCE"));
            if (upgradeButton.Text == "Upgrade")
                return true;
            return false;
        }

        public static void GoTo()
        {
            LeftNavigation.AddNote.Select();            
        }

        public static CreateNoteCommand CreateNote(string title)
        {
            return new CreateNoteCommand(title);
        }
    }

    public class CreateNoteCommand
    {
        private string content;
        private string title;

        public CreateNoteCommand(string title)
        {
            this.title = title;
        }
        public CreateNoteCommand WithContent(string content)
        {
            this.content = content;
            return this;
        }

        public void Done()
        {

            var titleInput = Driver.Instance.FindElement(By.Id("gwt-debug-NoteTitleView-textBox"));
            titleInput.SendKeys(title);


            var iframe = Driver.Instance.SwitchTo().Frame("en-common-editor-iframe");
            var contentInput = Driver.Instance.FindElement(By.Id("en-note"));
            contentInput.SendKeys(content);
            var defaultContent = Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(1));

            var doneButton = Driver.Instance.FindElement(By.Id("gwt-debug-NoteAttributes-doneButton"));
            doneButton.Click();
        } 
    }
}
