using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dp.Algorithms
{
    public class LinkedList<T> where T : IComparable
    {
        private LinkedNode<T>? _head;
        public LinkedNode<T>? Head => _head;
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public void Prepend(T data)
        {
            var node = new LinkedNode<T>(data);
            node.Next = _head;
            _head = node;
            _size++;
        }

        public T? RemoveFirst()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var data = _head!.Data;
            _head = _head.Next;
            _size--;
            return data;
        }

        public T? Peek()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return _head!.Data;
        }

        public T? PeekEnd()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var node = _head;
            while (node.Next != null) 
            { 
                node = node.Next;
            }
            return node.Data;
        }

        public void InsertAt(T data, int index)
        {
            if (index < 0 || index > Size)
            {
                throw new Exception("Invalid insertion index.");
            }
            if (index == 0)
            {
                Prepend(data);
                return;
            }
            var currentNode = _head;
            var node = new LinkedNode<T>(data);
            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode?.Next;
            }
            node.Next = currentNode?.Next;
            currentNode.Next = node;
            
            _size++;
        }

        public T? RemoveAt(int index)
        {
            if (index < 0 || index > Size - 1)
            {
                throw new Exception("Invalid removal index.");
            }
            if (index == 0)
            {
                return RemoveFirst();
            }
            var currentNode = _head;
            var nextNode = _head?.Next;
            for (int i = 1; i < index; i++)
            {
                currentNode = nextNode;
                nextNode = nextNode?.Next;
            }
            currentNode.Next = nextNode?.Next;
            _size--;
            return nextNode.Data;
        }

        public void RemoveData(T? data)
        {
            var currentNode = _head;
            var index = 0;
            while (currentNode != null) 
            {
                if (HelperMethods.Is1EqualTo2(currentNode.Data, data))
                {
                    RemoveAt(index);
                }
                else
                {
                    index++;
                }
                currentNode = currentNode?.Next;
            }
        }

        public void Append(T? data)
        {
            var node = new LinkedNode<T>(data);
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                var previous = _head;
                while (previous.Next != null)
                {
                    previous = previous.Next;
                }
                previous.Next = node;
            }
            _size++;
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
}
