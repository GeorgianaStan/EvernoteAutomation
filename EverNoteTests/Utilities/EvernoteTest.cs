using EverNoteAutomation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverNoteTests
{
    public class EvernoteTest
    {
        [SetUp]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("georgi.pluralsight27@gmail.com").Continue().WithPassword("georgiana").Login();
        }

        [TearDown]
        public void CleanUp()
        {
           Driver.Close();
        }
    }
}
