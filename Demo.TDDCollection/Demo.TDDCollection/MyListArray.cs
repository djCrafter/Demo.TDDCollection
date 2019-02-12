using System;
using System.Collections;
using System.Collections.Generic;


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

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _arr[index];
            }
            set
            {
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
            for (int i = 0; i < _count; ++i)
                if (Equals(_arr[i], item))
                    return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex + _count > array.Length)
                throw new ArgumentException();
            else if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            else
                for (int i = 0, j = arrayIndex; i < _count; ++i, ++j)
                    array[j] = _arr[i];
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; ++i)
                if (Equals(item, _arr[i]))
                    return i;
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();

            T temp = _arr[index];

            for (int i = index; i < _count; ++i)
            {
                _arr[i] = item;
                item = temp;
            }
            Add(item);
        }

        public bool Remove(T item)
        {
            bool flag = false;

            for (int i = 0; i < _count; ++i)
            {
                if (Equals(item, _arr[i]))
                    flag = true;

                if (flag)
                    if (i + 1 < _count)
                        _arr[i] = _arr[i + 1];
            }
            if (flag)
                _count--;

            return flag;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < _count; ++i)           
                if (i + 1 < _count)
                    _arr[i] = _arr[i + 1];

            _count--;
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
