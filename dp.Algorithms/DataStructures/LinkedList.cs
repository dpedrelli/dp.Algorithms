using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dp.Algorithms
{
    public class LinkedList<T> where T : IComparable<T>
    {
        public LinkedNode<T>? Head { get; set; }
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public void Prepend(T data)
        {
            var node = new LinkedNode<T>(data);
            node.Next = Head;
            Head = node;
            _size++;
        }

        public T? RemoveFirst()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var data = Head!.Data;
            Head = Head.Next;
            _size--;
            return data;
        }

        public T? Peek()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return Head!.Data;
        }

        public T? PeekEnd()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var node = Head;
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
            var currentNode = Head;
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
            var currentNode = Head;
            var nextNode = Head?.Next;
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
            var currentNode = Head;
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
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                var previous = Head;
                while (previous.Next != null)
                {
                    previous = previous.Next;
                }
                previous.Next = node;
            }
            _size++;
        }
    }
}
