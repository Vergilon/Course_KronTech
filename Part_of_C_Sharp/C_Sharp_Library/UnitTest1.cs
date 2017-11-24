using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KT_Test;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Book book1;
        Book book2;
        Library lib;

        Abonent ab1 = new Abonent("John", 214875);
        
        
        [TestInitialize]
        public void SetUp()
        {
            book1 = new Book("Gilbert", "I don't know", true);
            book2 = new Book("Gilbert_2", "I don't know_2", true);

            lib = new Library();

            //ab1 = new Abonent("John", 214875);

            EventHandler<string> add = (sender, str) => Console.WriteLine(str);
            lib.nb += add;
            lib.Add_Book(book1, book2);
            lib.Give_Book(ab1, book1);

        }

        [TestMethod]
        public void Test_Give_Book()
        {
            lib.Give_Book(ab1, book1);
        }

        [TestMethod]
        public void Test_Index_Ab()
        {
            String expected_name = "Gilbert";
            String actual_name = ab1[0].author;
            Assert.AreEqual(expected_name, actual_name);
        }

        [TestMethod]
        public void Test_Index_Lib()
        {
            lib.Add_Book(book1, book2);
            Assert.AreEqual("I don't know", lib["Gilbert", "I don't know"].name);
        }

        [TestMethod]
        public void Test_FullList()
        {
            Assert.AreEqual("Gilbert_2", lib.FullList()[0].author);
        }

        [TestMethod]
        public void Test_Find_author()
        {
            Assert.AreEqual("I don't know_2", lib.Find("Gilbert_2", false)[0].name);
        }

        [TestMethod]
        public void Test_Find_Title()
        {
            Assert.AreEqual("I don't know_2", lib.Find("I don't know_2", true)[0].name);
        }

        [TestMethod]
        public void Test_Get_Inf_Abonent()
        {
            Assert.AreEqual("Name John with telephone 214875", ab1.Get_Inf());
        }

        [TestMethod]
        public void Test_Abonent_Book()
        {
            Assert.AreEqual("I don't know", ab1.ListBooks()[0].name);
        }

        [TestMethod]
        public void Test_Abonent_Overd_Book()
        {
            Assert.AreEqual("I don't know", ab1.OverdueBooks()[0].name);
        }

        [TestMethod]
        public void Change_status_issue()
        {

            Assert.IsTrue(book1.abonent != null);
        }

        [TestMethod]
        public void Overdue_Date()
        {
            lib.Give_Book(ab1, book1);
            Assert.IsTrue(book1.Overdue_Book());
        }

        [TestMethod]
        public void Get_Info_Where_Book()
        {
            Assert.IsFalse(book2.Get_Info_Where_Book());
        }

        [TestMethod]
        public void Event_AddBook()
        {
            List<string> receivedEvents = new List<string>();
            Library lib = new Library();

            lib.nb += delegate (object sender, string str)
            {
                receivedEvents.Add(str);
            };

            lib.Add_Book(new Book("test1", "test1", true));
            lib.Add_Book(new Book("test2", "test2", false));

            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("Add book: test1", receivedEvents[0]);
            Assert.AreEqual("Add book: test2", receivedEvents[1]);
        }

        [TestMethod]
        public void Event_AddAbonent()
        {
            List<string> receivedEvents = new List<string>();
            Library lib = new Library();

            lib.nb += delegate (object sender, string str)
            {
                receivedEvents.Add(str);
            };

            Book boook = new Book("test1", "test1", false);
            lib.Add_Book(boook);

            lib.Give_Book(ab1, boook);

            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("Add new abonent: John", receivedEvents[1]);
        }

        [TestMethod]
        public void Event_ChangeStatusBook()
        {

            Library library = new Library();
            List<string> Event = new List<string>();
            Abonent ab2 = new Abonent("John", 214875);
            library.nb += delegate (object sender, string str)
            {
                Event.Add(str);
            };

            Book bk1 = new Book("t", "t", false);
            library.Add_Book(bk1);

            library.Give_Book(ab2, bk1);

            Assert.AreEqual(3, Event.Count);
            Assert.AreEqual("Change book status: t by t was taken John", Event[2]);
        }

        [TestCleanup]
        public void TearDown()
        {
            book1 = null;
            book2 = null;
            lib = null;
            ab1 = null;
        }


    }
}
