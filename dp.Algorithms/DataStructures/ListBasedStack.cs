using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class ListBasedStack<T> where T : IComparable
    {
        private LinkedNode<T>? _head;
        public LinkedNode<T>? Head => _head;
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public void Push(T data)
        {
            var node = new LinkedNode<T>(data);
            node.Next = _head;
            _head = node;
            _size++;
        }

        public T? Peek()
        {
            if (_size == 0 || _head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return _head.Data;
        }

        public T? Pop()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            var result = Head.Data;
            if (Head.Next == null)
            {
                _head = null;
            }
            else
            {
                _head = _head.Next;
            }
            _size--;
            return result;
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
