using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class HashTable
    {
        private int _size;
        public int Size => _size;
        public bool IsEmpty => _size == 0;
        private double _loadFactor = 0.75;
        private DoublyLinkedList<Tuple>[] _hashTable;
        private int _capacity;
        public int Capacity => _capacity;

        public HashTable(int initialCapacity = 16)
        {
            _capacity = initialCapacity;
            _hashTable = new DoublyLinkedList<Tuple>[_capacity];
            for (int i = 0; i < _capacity; i++)
            {
                _hashTable[i] = new DoublyLinkedList<Tuple>();
            }
            _size = 0;
        }

        private int ComputeIndex(object key)
        {
            int hashCode;
            if (key is string)
            {
                hashCode = Math.Abs(GetDeterministicHashCode((string)key));
            }
            else 
            {
                hashCode = key.GetHashCode();
            }
            return hashCode % _capacity;
        }

        public void Put(object key, object value) 
        { 
            var index = ComputeIndex(key);
            _hashTable[index].Reset();
            var current = _hashTable[index].GetNext();
            while (current != null) 
            { 
                if (current.Key == key)
                {
                    current.Value = value;
                    return;
                }
                current = _hashTable[index].GetNext();
            }

            _hashTable[index].Append(new Tuple(key, value));
            _size++;

            if (_size / Capacity > _loadFactor)
            {
                doubleCapacity();
            }
        }

        public object? Get(object key) 
        {
            var index = ComputeIndex(key);
            _hashTable[index].Reset();
            var current = _hashTable[index].GetNext();
            while (current != null)
            {
                if (current.Key == key)
                {
                    return current.Value;
                }
                current = _hashTable[index].GetNext();
            }
            return null;
        }

        public object? Remove(object key) 
        {
            var index = ComputeIndex(key);
            _hashTable[index].Reset();
            var current = _hashTable[index].GetNext();
            while (current != null)
            {
                if (current.Key == key)
                {
                    var value = current.Value;
                    _hashTable[index].RemoveCurrent();
                    _size--;
                    return value;
                }
                current = _hashTable[index].GetNext();
            }
            return null;
        }

        public bool ContainsKey(object key)
        {
            var index = ComputeIndex(key);
            _hashTable[index].Reset();
            var current = _hashTable[index].GetNext();
            while (current != null)
            {
                if (current.Key == key)
                {
                    return true;
                }
                current = _hashTable[index].GetNext();
            }
            return false;
        }

        public bool ContainsValue(object value)
        {
            for (int i = 0; i < Capacity; i++)
            {
                _hashTable[i].Reset();
                var current = _hashTable[i].GetNext();
                while (current != null)
                {
                    if (current.Value == value)
                    {
                        return true;
                    }
                    current = _hashTable[i].GetNext();
                }
            }
            return false;
        }

        public HashTable Copy()
        {
            var newHashTable = new HashTable(Capacity);
            for (int i = 0; i < Capacity; i++)
            {
                _hashTable[i].Reset();
                var current = _hashTable[i].GetNext();
                while (current != null)
                {
                    newHashTable.Put(current.Key, current.Value);
                    current = _hashTable[i].GetNext();
                }
            }
            return newHashTable;
        }

        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < Capacity; i++)
            {
                _hashTable[i].Reset();
                var current = _hashTable[i].GetNext();
                while (current != null)
                {
                    result += current.ToString() + ", ";
                    current = _hashTable[i].GetNext();
                    //if (current != null)
                    //{
                    //    result += ", ";
                    //}
                }
            }
            return result;
        }

        private void doubleCapacity()
        {
            var newCapacity = Capacity * 2;
            var newHashTable = new DoublyLinkedList<Tuple>[newCapacity];
            for (int i = 0; i < newCapacity; i++)
            {
                newHashTable[i] = new DoublyLinkedList<Tuple>();
            }

            for (int i = 0; i < Capacity; i++)
            {
                _hashTable[i].Reset();
                var current = _hashTable[i].GetNext();
                while (current != null)
                {
                    var index = ComputeIndex(current);
                    var tupel = new Tuple(current.Key, current.Value);
                    newHashTable[index].Append(tupel);
                    current = _hashTable[i].GetNext();
                }
            }
            _capacity = newCapacity;
            _hashTable = newHashTable;
        }

        // https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/
        static int GetDeterministicHashCode(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

    }
}
