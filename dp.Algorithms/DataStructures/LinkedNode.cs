﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class LinkedNode<T> where T : IComparable
    {
        public T? Data { get; set; }
        public LinkedNode<T>? Next { get; set; }

        public LinkedNode(T? data)
        {
            Data = data;
        }
    }
    public class DoublyLinkedNode<T> where T : IComparable
    {
        public T? Data { get; set; }
        public DoublyLinkedNode<T>? Previous { get; set; }
        public DoublyLinkedNode<T>? Next { get; set; }

        public DoublyLinkedNode(T? data, DoublyLinkedNode<T>? previous = null)
        {
            Data = data;
            Previous = previous;
        }
    }
}
