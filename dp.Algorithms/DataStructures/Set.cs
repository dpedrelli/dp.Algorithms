using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dp.Algorithms
{
    public class Set<T> : DoublyLinkedList<T> where T : IComparable
    {
        public bool Contains(T value)
        {
            Reset();
            var data = GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default)) 
            { 
                if (HelperMethods.Is1EqualTo2(data, value)) return true;
                data = GetNext();
            }
            return false;
        }

        public bool Add(T value)
        {
            if (Contains(value)) { return false; }
            Append(value);
            return true;
        }

        public bool Remove(T value) 
        {
            Reset();
            var data = GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default))
            {
                if (HelperMethods.Is1EqualTo2(data, value))
                {
                    RemoveCurrent();
                    return true;
                }
                data = GetNext();
            }
            return false;
        }

        public Set<T> Intersection(Set<T> set)
        {
            var result = new Set<T>();
            Reset();
            var data = GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default))
            {
                if (set.Contains(data))
                {
                    result.Add(data);
                }
                data = GetNext();
            }
            return result;
        }

        public Set<T> Union(Set<T> set)
        {
            var result = new Set<T>();
            Reset();
            var data = GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default))
            {
                result.Add(data);
                data = GetNext();
            }

            set.Reset();
            data = set.GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default))
            {
                result.Add(data);
                data = set.GetNext();
            }
            return result;
        }

        public bool IsSubset(Set<T> set)
        {
            set.Reset();
            var data = set.GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default))
            {
                if (!Contains(data)) {  return false; }
                data = set.GetNext();
            }
            return true;
        }
    }
}
