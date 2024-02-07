using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public class Tuple : IComparable
    {
        public object Key { get; set; }
        public object Value { get; set; }

        public Tuple(object key, object value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString() 
        { 
            return "(" + Key + ", " + Value + ")";
        }

        public override bool Equals(object? other) 
        { 
            if (ReferenceEquals(null, other)) return false;
            if (other.GetType() != typeof(Tuple)) return false;
            Tuple o = (Tuple)other;
            if (Key.Equals(o.Key)  && Value.Equals(o.Value))
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
