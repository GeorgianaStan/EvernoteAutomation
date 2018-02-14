namespace EverNoteAutomation
{
    public class LeftNavigation
    {
        public class NewNote
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-newNoteButton-container");
            }
        }

        public class NewMeetingNote
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-newCalendarNoteButton-container");
            }
        }

        public class SearchNote
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-searchButton-container");
            }
        }

        public class WorkChat
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-workChatButton-container");
            }
        }

        public class Shorcut
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-shortcutsButton-container");
            }
        }
        
        public class Notes
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-notesButton-container");
            }
        }

        public class Notebooks
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-notebooksButton-container");
            }
        }

        public class Tags
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-Sidebar-tagsButton-container");
            }
        }

        public class Account
        {
            public static void Select()
            {
                MenuSelector.Select("gwt-debug-AccountMenu-avatar");
            }
        }
    }
}
