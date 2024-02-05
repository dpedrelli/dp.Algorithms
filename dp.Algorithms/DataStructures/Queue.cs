using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class Queue<T>
    {
        private T[] _queue;
        private int start = -1;
        private int end = 0;
        public int Capacity => _queue.Length;
        public bool IsFull => start == end;
        public bool IsEmpty => start == -1;

        public Queue(int capacity)
        {
            if (capacity < 1)
            {
                throw new Exception("Invalid queue capacity.");
            }
            _queue = new T[capacity];
        }

        public int NumberInQueue
        {
            get
            {
                if (IsEmpty)
                {
                    return 0;
                }
                else if (IsFull)
                {
                    return Capacity;
                }
                else if (start < end)
                {
                    return end;
                }
                else
                {
                    return end + (Capacity - start);
                }
            }
        }

        public void Enqueue(T item)
        {
            if (IsFull)
            {
                throw new Exception("Queue is full.");
            }
            _queue[end] = item;
            end = (end + 1) % Capacity;
            if (start == -1)
            {
                start = 0;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty.");
            }
            var item = _queue[start];
            start = (start + 1) % Capacity;
            if (start == end)
            {
                start = -1;
                end = 0;
            }
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty.");
            }
            return _queue[start];
        }

        public void ChangeCapacity(int newCapacity)
        {
            if (newCapacity < end)
            {
                throw new Exception("Invalid queue capacity.");
            }
            Array.Resize(ref _queue, newCapacity);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _queue.Length; i++)
            {
                var index = (start + i) % Capacity;
                if (end > start && index < start) { continue; }
                if (end > start && index >= end) { continue; }
                if (index >= end && index < start) { continue; } // Allowing for wrapping arrays.
                result += _queue[index].ToString();
            }
            return result;
        }
    }
}
