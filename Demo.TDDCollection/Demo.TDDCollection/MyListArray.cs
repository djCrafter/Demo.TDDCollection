using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.TDDCollection
{
    public class MyListArray<T> : IList<T>, IEnumerator<T>
    {
        #region private fields

        private T[] _arr;
        private int _count;

        #endregion
        
        #region .ctors

        public MyListArray(int startCapacity = 10)
        {
            _arr = new T[startCapacity];
            _count = 0;
        }

        #endregion

        #region indexer

        public T this[int index] {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _arr[index];
            }
            set {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                _arr[index] = value;
            }
        }

        #endregion

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T val)
        {
            if (_count == _arr.Length)
            {
                Array.Resize(ref _arr, _count + 10);
            }
            _arr[_count++] = val;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        #region Enumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Enumerator

        int _currentIndex = -1;

        public T Current => _arr[_currentIndex];
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {           
            return ++_currentIndex < _count;
        }
        public void Reset()
        {
            _currentIndex = -1;
        }
        public void Dispose()
        {
            Reset();
        }

        #endregion;
    }
}
