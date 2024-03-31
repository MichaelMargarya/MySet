using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySet
{
    public class Sets<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly List<T> _items = new List<T>();
        public Sets()
        {

        }
        public Sets(IEnumerable<T> item)
        {
            AddRange(item);
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("Item already exists in Set");
            }
            _items.Add(item);
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public bool Contains(T item)
        {
           return _items.Contains(item);
        }

        public int Count { get { return _items.Count; } }
        public Sets<T> Union(Sets<T> other)
        {
            Sets<T> union = [..other];
            foreach(T item in _items)
            {
                if(!union.Contains(item))
                {
                    union.Add(item);
                }
            }
            return union;
        }
        public Sets<T> Intersection(Sets<T> other)
        {
            var intersection = new Sets<T>();
            foreach (var item in _items)
            {
                if (other.Contains(item))
                {
                    intersection.Add(item);
                }
            }
            return intersection;

        }
        public Sets<T> Difference(Sets<T> other)
        {
            var difference = new Sets<T>(_items);
            foreach (var item in other)
            {
                difference.Remove(item);
            }
            return difference;

        }
        public Sets<T> SymmetricDifference(Sets<T> other)
        {
            var symmetricDifference = new Sets<T>();
            symmetricDifference.AddRange(other._items.Except(_items));
            return symmetricDifference;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
