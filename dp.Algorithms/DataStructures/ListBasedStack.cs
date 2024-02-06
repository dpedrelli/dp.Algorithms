using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class ListBasedStack<T> where T : IComparable<T>
    {
        public LinkedNode<T>? Head { get; set; }
        private int _size;
        public int Size { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public void Push(T data)
        {
            var node = new LinkedNode<T>(data);
            node.Next = Head;
            Head = node;
            _size++;
        }

        public T? Peek()
        {
            if (_size == 0 || Head == null)
            {
                throw new Exception("Invalid list size.");
            }
            return Head.Data;
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
                Head = null;
            }
            else
            {
                Head = Head.Next;
            }
            _size--;
            return result;
        }
    }
}
