using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        public DoublyLinkedNode<T>? Head { get; set; }
        public DoublyLinkedNode<T>? Tail { get; set; }
        public DoublyLinkedNode<T>? Current { get; set; }
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public void Prepend(T? data)
        {
            var node = new DoublyLinkedNode<T>(data);
            node.Next = Head;
            if (Head != null)
            {
                Head.Previous = node;
            }
            Head = node;
            if (Tail == null) 
            { 
                Tail = node; 
            }
            _size++;
        }

        public void Append(T? data)
        {
            var node = new DoublyLinkedNode<T>(data);
            node.Previous = Tail;
            if (Tail != null)
            {
                Tail.Next = node;
            }
            Tail = node;
            if (Head == null)
            {
                Head = node;
            }
            _size++;
        }

        public void InsertAt(T? data, int index)
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
                var currentNode = Head;
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

        public T? Peek()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return Head!.Data;
        }

        public T? RemoveFirst()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var data = Head!.Data;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            else
            {
                Head!.Previous = null;
            }
            _size--;
            return data;
        }

        public T? RemoveLast()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var data = Tail!.Data;
            Tail = Tail.Previous;
            if (Tail == null)
            {
                Head = null;
            }
            else
            {
                Tail!.Next = null;
            }
            _size--;
            return data;
        }

        public T? RemoveAt(int index)
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
                var currentNode = Head?.Next;
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
    }
}
