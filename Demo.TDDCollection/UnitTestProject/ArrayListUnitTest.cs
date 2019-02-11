using System;
using System.Collections;
using System.Collections.Generic;
using Demo.TDDCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ListArrayUnitTest
    {
        [TestMethod]
        public void Ctor_1_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>();
            Assert.IsNotNull(list);
            Assert.IsFalse(list.IsReadOnly);
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Ctor_2_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(100);
            Assert.IsNotNull(list);
            Assert.IsFalse(list.IsReadOnly);
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void AddAndCountTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            Assert.AreEqual(0, list.Count);
            list.Add(100);
            Assert.AreEqual(1, list.Count);
            list.Add(101);
            Assert.AreEqual(2, list.Count);
            list.Add(102);
            Assert.AreEqual(3, list.Count);
            list.Add(103);
            Assert.AreEqual(4, list.Count);
        }
        [TestMethod]
        public void IndexTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);            
            list.Add(100);            
            list.Add(101);
            list.Add(102);            
            list.Add(103);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(100, list[0]);
            Assert.AreEqual(101, list[1]);
            Assert.AreEqual(102, list[2]);
            Assert.AreEqual(103, list[3]);
            list[0] = 0;
            Assert.AreEqual(0, list[0]);
            list[1] = 1;
            Assert.AreEqual(1, list[1]);
            list[2] = 2;
            Assert.AreEqual(2, list[2]);
            list[3] = 3;
            Assert.AreEqual(3, list[3]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_get0_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);            
            int x = list[1];
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_get1_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            int x = list[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_set0_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list[1]=1;
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_set1_TestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list[-1]=10;
        }

        [TestMethod]
        public void ClearTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(2);
            list.Add(100);
            list.Add(101);
            list.Add(102);
            list.Add(103);
            Assert.AreEqual(4, list.Count);
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void IEnumerableTestMethod()
        {
            MyListArray<int> list = new MyListArray<int>(100);
            var e = list.GetEnumerator();
            Assert.IsFalse(e.MoveNext());
            e.Reset();
            int[] mas = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach(int val in mas)
            {
                list.Add(val);
            }
            int count = 0;
            using (IEnumerator<int> le = list.GetEnumerator())
            {
                while (le.MoveNext())
                    Assert.AreEqual(le.Current, mas[count++]);
            }
        }
    }
}
