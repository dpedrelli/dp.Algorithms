using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class HashTableBasedSet
    {
        private HashTable _hashTable = new HashTable();
        public int Size => _hashTable.Size;
        public bool Contains(object data)
        {
            return _hashTable.ContainsKey(data);
        }

        public bool Add(object data) 
        { 
            if (_hashTable.ContainsKey(data))
            {
                return false;
            }
            _hashTable.Put(data, data);
            return true;
        }

        public bool Remove(object data)
        {
            return (_hashTable.Remove(data) != null);
        }

        public void Reset()
        {
            _hashTable.Reset(); 
        }

        public object? GetNext()
        {
            return _hashTable.GetNext();
        }

        public HashTableBasedSet Copy()
        {
            var result = new HashTableBasedSet();
            Reset();
            var data = GetNext();
            while (data != null)
            {
                result.Add(data);
                data = GetNext();
            }
            return result;
        }

        public HashTableBasedSet Intersection(HashTableBasedSet set2)
        {
            var result = new HashTableBasedSet();
            Reset();
            var data = GetNext();
            while (data != null) 
            {
                if (set2.Contains(data))
                {
                    result.Add(data);
                }
                data = GetNext();
            }
            return result;
        }

        public HashTableBasedSet Union(HashTableBasedSet set2)
        {
            var result = Copy();
            set2.Reset();
            var data = set2.GetNext();
            while (data != null)
            {
                if (!result.Contains(data))
                {
                    result.Add(data);
                }
                data = set2.GetNext();
            }
            return result;
        }

        public bool IsSubset(HashTableBasedSet set2)
        {
            set2.Reset();
            var data = set2.GetNext();
            while (data != null) 
            {
                if (!Contains(data)) { return false; }
                data = set2.GetNext();
            }
            return true;
        }
    }
}
