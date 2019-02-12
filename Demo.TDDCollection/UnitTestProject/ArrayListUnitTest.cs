using System;
using System.Collections.Generic;
using Demo.TDDCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ListArrayUnitTest
    {
        MyListArray<int> list;

        class TestClass
        {
            public string str1;
            public string str2;

            public TestClass()
            {
                str1 = "str1";
                str2 = "str2";
            }
        }
       
        [TestInitialize]
        public void TestInitialize()
        {
            list = new MyListArray<int>(2);
        }
        
        [TestMethod]
        public void Ctor_1_TestMethod()
        {
            list = new MyListArray<int>(2);
            Assert.IsNotNull(list);
            Assert.IsFalse(list.IsReadOnly);
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Ctor_2_TestMethod()
        {
            list = new MyListArray<int>(100);
            Assert.IsNotNull(list);
            Assert.IsFalse(list.IsReadOnly);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void AddAndCountTestMethod()
        {       
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
            int x = list[1];
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_get1_TestMethod()
        {       
            int x = list[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_set0_TestMethod()
        {        
            list[1]=1;
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexException_set1_TestMethod()
        {       
            list[-1]=10;
        }

        [TestMethod]
        public void ClearTestMethod()
        {           
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

        [TestMethod]
        public void ContainsTestMethod_1()
        {      
            list.Add(11);
            Assert.IsTrue(list.Contains(11));
            Assert.IsFalse(list.Contains(12));
        }

        [TestMethod]
        public void ContainsTestMethod_2()
        {
            MyListArray<string> list = new MyListArray<string>();

            list.Add("Строка");

            Assert.IsTrue(list.Contains("Строка"));
            Assert.IsFalse(list.Contains("Строк"));
        }

        [TestMethod]
        public void ContainsTestMethod_3()
        {
            MyListArray<TestClass> list = new MyListArray<TestClass>();

            TestClass testClass = new TestClass();
            TestClass testClass2 = new TestClass();
            list.Add(testClass);

            testClass.str1 = "new val";
            Assert.IsTrue(list.Contains(testClass));
            Assert.IsFalse(list.Contains(testClass2));
        }

        [TestMethod]
        public void CopyTo_TestMethod_1()
        {           
            int[] arr1 = { 1, 1 };
            foreach(int val in arr1)
                list.Add(val);

            int[] arr2 = { 2, 2, 2, 2, 2, 2, 2 };

            list.CopyTo(arr2, 3);
            Assert.AreEqual(1, arr2[3]);
            Assert.AreEqual(1, arr2[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_TestMethod_2()
        { 
            int[] arr1 = { 1, 1 };
            foreach (int val in arr1)
                list.Add(val);

            int[] arr2 = { 2, 2, 2, 2, 2, 2, 2 };

            list.CopyTo(arr2, 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_TestMethod_3()
        {  
            int[] arr1 = { 1, 1 };
            foreach (int val in arr1)
                list.Add(val);

            int[] arr2 = { 2, 2, 2, 2, 2, 2, 2 };

            list.CopyTo(arr2, -1);
        }
        
        [TestMethod]
        public void IndexOf_TestMethod_1()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(1, list.IndexOf(2));
        }

        [TestMethod]
        public void IndexOf_TestMethod_2()
        {  
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(-1, list.IndexOf(10));
        }

        [TestMethod]
        public void Insert_TestMethod_1()
        {
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Insert(1, 2);

            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_TestMethod_2()
        {
            list.Add(1);
            list.Insert(3, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_TestMethod_3()
        {
            list.Add(1);
            list.Insert(-1, 2);
        }

        [TestMethod]
        public void Insert_TestMethod_4()
        {
            list.Add(1);           
            list.Insert(0, 2);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);           
        }

        [TestMethod]
        public void Remove_TestMethod_1()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Remove(2);

            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        public void Remove_TestMethod_2()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.IsTrue(list.Remove(2));
        }

        [TestMethod]
        public void Remove_TestMethod_3()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.IsFalse(list.Remove(10));
        }

        [TestMethod]
        public void RemoveAt_TestMethod_1()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);

            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_TestMethod_2()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_TestMethod_3()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(-1);
        }
    }
}
