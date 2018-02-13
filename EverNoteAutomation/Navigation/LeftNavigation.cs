namespace EverNoteAutomation
{
    public class LeftNavigation
    {
        public class AddNote
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-newNoteButton-container");
            }
        }

        public class Notes
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-notesButton-container");
            }
        }
    }
}
