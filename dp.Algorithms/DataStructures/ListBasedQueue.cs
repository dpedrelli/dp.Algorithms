using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class ListBasedQueue<T> where T : IComparable<T>
    {
        private DoublyLinkedNode<T>? _head;
        private DoublyLinkedNode<T>? _tail;
        public DoublyLinkedNode<T>? Head => _head;
        public DoublyLinkedNode<T>? Tail => _tail;
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public void Enqueue(T? data)
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

        public T? Dequeue()
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

        public T? Peek()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return _head!.Data;
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
