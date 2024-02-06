using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dp.Algorithms
{
    public class LinkedNode<T> where T : IComparable<T>
    {
        public T? Data { get; set; }
        public LinkedNode<T>? Next { get; set; }

        public LinkedNode(T? data)
        {
            Data = data;
        }
    }

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
            var nextNode = Head?.Next;
            var node = new LinkedNode<T>(data);
            for (int i = 1; i < index; i++)
            {
                currentNode = nextNode;
                nextNode = currentNode?.Next;
            }
            currentNode.Next = node;
            node.Next = nextNode;
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
    }
}
