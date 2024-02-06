using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class Stack<T>
    {
        private T[] _stackArray;
        private int _top = -1;
        public int Capacity => _stackArray.Length;
        public bool IsFull => _top == _stackArray.Length - 1;
        public bool IsEmpty => _top == -1;
        public int Size => _top + 1;
        public Stack(int capacity) 
        { 
            _stackArray = new T[capacity];
        }

        public void Push(T value) 
        {
            if (IsFull)
            {
                throw new Exception("Stack is full.");
            }
            _stackArray[++_top] = value;
        }

        public T Pop() 
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty.");
            }
            return _stackArray[_top--];
        }

        public T Peek() 
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty.");
            }
            return _stackArray[_top];
        }

        public void ChangeCapacity(int newCapacity)
        {
            if (newCapacity <= _top + 1)
            {
                throw new Exception("Invalid stack capacity.");
            }
            Array.Resize(ref _stackArray, newCapacity);
        }

        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < _top + 1; i++)
            {
                result += _stackArray[i]?.ToString();
            }
            return result;
        }

        public void DoubleCapacity()
        {
            ChangeCapacity(Capacity * 2);
        }

        public void HalveCapacity()
        {
            ChangeCapacity(Capacity / 2);
        }
    }
}
