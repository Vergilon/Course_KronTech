using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KT_Two_Forked;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest
    {
        Two_Forked_List<int> testList;

        [TestInitialize]
        public void Test_Init()
        {
            testList = new Two_Forked_List<int>();
        }

        [TestMethod]
        public void List_Add()
        {
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            Assert.AreEqual(0, testList.first.item);
            Assert.AreEqual(3, testList.last.item);
            Assert.AreEqual(4, testList.Count);
        }

        [TestMethod]
        public void List_Contains()
        {
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            Assert.IsTrue(testList.Contains(2));
            Assert.IsFalse(testList.Contains(4));

        }

        [TestMethod]
        public void List_CopyTo()
        {
            int[] array = new int[10];
            testList.Add(1);
            testList.Add(1);
            testList.Add(1);
            testList.Add(1);
            testList.CopyTo(array, 4);
            for (int i = 0; i < array.Length; i++)
            {
                if (i < 4)
                    Assert.IsTrue(array[i] == 0);
                else if (i >= 4 && i < array.Length - 2)
                    Assert.IsTrue(array[i] == 1);
            }

        }
        [TestMethod]
        public void List_Remove()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Remove(2);
            Assert.AreEqual(3, testList.Count);
            Assert.IsTrue(testList.first.next.item == 3);
        }
        [TestMethod]
        public void List_GetEnumerator()
        {
            testList.Add(1);
            testList.Add(2);
            int i = 1;
            foreach (int a in testList)
            {
                Assert.AreEqual(a, i++);
            }
        }
        [TestMethod]
        public void List_Insert()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);
            testList.Insert(7, 3);
            Assert.AreEqual(5, testList.Count);
            Assert.AreEqual(7, testList.first.next.next.item);
        }

        [TestMethod]
        public void List_Actions()
        {
            List<string> events = new List<string>();
            testList.Added += delegate (int add) { events.Add($"Add = {add}"); };
            testList.Removed += delegate (int rem) { events.Add($"Remove = {rem}"); };
            testList.Cleared += delegate { events.Add("Clear"); };
            testList.Add(1);
            testList.Add(2);
            testList.Remove(2);
            testList.Clear();
            Assert.AreEqual("Add = 1", events[0]);
            Assert.AreEqual("Remove = 2", events[2]);
            Assert.AreEqual("Clear", events[3]);
        }

        [TestCleanup]
        public void Test_Clean()
        {
            testList = null;
        }

    }
}
