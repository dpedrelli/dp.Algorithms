using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class BaseDoublyLinkedList<T> where T : IComparable<T>
    {
        private DoublyLinkedNode<T>? _head;
        private DoublyLinkedNode<T>? _tail;
        private DoublyLinkedNode<T>? _current;
        public DoublyLinkedNode<T>? Head => _head;
        public DoublyLinkedNode<T>? Tail => _tail;
        public DoublyLinkedNode<T>? Current => _current;
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        protected virtual void Prepend(T? data)
        {
            var node = new DoublyLinkedNode<T>(data);
            node.Next = _head;
            if (_head != null)
            {
                _head.Previous = node;
            }
            _head = node;
            if (_tail == null) 
            { 
                _tail = node; 
            }
            _size++;
        }

        protected virtual void Append(T? data)
        {
            var node = new DoublyLinkedNode<T>(data);
            node.Previous = _tail;
            if (_tail != null)
            {
                _tail.Next = node;
            }
            _tail = node;
            if (_head == null)
            {
                _head = node;
            }
            _size++;
        }

        protected virtual void InsertAt(T? data, int index)
        {
            if (index < 0 || index > Size)
            {
                throw new Exception("Invalid insertion index.");
            }
            if (index == 0)
            {
                Prepend(data);
            }
            else if (index == _size + 1)
            {
                Append(data);
            }
            else
            {
                var currentNode = _head;
                var node = new DoublyLinkedNode<T>(data);
                for (int i = 1; i < index; i++)
                {
                    currentNode = currentNode?.Next;
                }
                node.Next = currentNode?.Next;
                node.Previous = currentNode;
                node.Next.Previous = node;
                currentNode.Next = node;
                _size++;
            }
        }

        protected virtual T? Peek()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return _head!.Data;
        }

        protected virtual T? PeekEnd()
        {
            if (_size == 0 || _tail == null)
            {
                throw new Exception("Invalid list size.");
            }
            return _tail!.Data;
        }

        protected virtual T? RemoveFirst()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var data = _head!.Data;
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            }
            else
            {
                _head!.Previous = null;
            }
            _size--;
            return data;
        }

        protected virtual T? RemoveLast()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var data = _tail!.Data;
            _tail = _tail.Previous;
            if (_tail == null)
            {
                _head = null;
            }
            else
            {
                _tail!.Next = null;
            }
            _size--;
            return data;
        }

        protected virtual T? RemoveAt(int index)
        {
            if (index < 0 || index > Size)
            {
                throw new Exception("Invalid insertion index.");
            }
            if (index == 0)
            {
                return RemoveFirst();
            }
            else if (index == _size + 1)
            {
                return RemoveLast();
            }
            else
            {
                var currentNode = _head?.Next;
                for (int i = 1; i < index; i++)
                {
                    currentNode = currentNode?.Next;
                }
                currentNode.Next.Previous = currentNode.Previous;
                currentNode.Previous.Next = currentNode.Next;
                _size--;
                return currentNode.Data;
            }
        }

        public void Reset()
        {
            _current = null;
        }

        public T? GetNext()
        {
            if (_current == null)
            {
                _current = _head;
            }
            else
            {
                _current = _current.Next;
            }
            if (_current == null)
            {
                return default;
            }
            return _current.Data;
        }

        public void RemoveCurrent()
        {
            if (_current == null)
            {
                throw new Exception("No current element.");
            }
            if (_current.Previous != null)
            {
                _current.Previous.Next = _current.Next;
            }
            else
            {
                _head = _current.Next;
            }
            if (_current.Next != null)
            {
                _current.Next.Previous = _current.Previous;
            }
            else
            {
                _tail = _current.Previous;
            }
            _current = _current.Previous;
            _size--;
        }

        protected virtual void DeleteAll(T? value)
        {
            Reset();
            var data = GetNext();
            while (!HelperMethods.Is1EqualTo2(data, default))
            {
                if (HelperMethods.Is1EqualTo2(value, data))
                {
                    RemoveCurrent();
                }
                data = GetNext();
            }
        }

        public override string ToString()
        {
            var result = "";
            var current = _head;
            while (current != null)
            {
                result += current?.Data?.ToString();
                current = current?.Next;
            }
            return result;
        }
    }

    public class DoublyLinkedList<T> : BaseDoublyLinkedList<T> where T : IComparable<T>
    {
        public new void Prepend(T? data)
        {
            base.Prepend(data);
        }

        public new void Append(T? data)
        { 
            base.Append(data); 
        }

        public new void InsertAt(T? data, int index)
        { 
            base.InsertAt(data, index);
        }

        public new T? Peek()
        { 
            return base.Peek(); 
        }

        public new T? PeekEnd()
        {
            return base.PeekEnd();
        }

        public new T? RemoveFirst()
        {
            return base.RemoveFirst();
        }

        public new T? RemoveLast()
        {
            return base.RemoveLast();
        }

        public new T? RemoveAt(int index)
        {
            return base.RemoveAt(index);
        }

        public new void DeleteAll(T? value)
        {
            base.DeleteAll(value);
        }
    }
}
