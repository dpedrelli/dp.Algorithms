using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
