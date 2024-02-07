using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class TupleTester
    {
        [Theory]
        [InlineData("key", "value", "key", "value", true)]
        [InlineData("key", "value", "key2", "value2", false)]
        public void Equals_CreateTwoTuples_ConfirmEquality(object key1, object value1, object key2, object value2, bool expected) 
        { 
            var tuple1 = new Tuple(key1, value1);
            var tuple2 = new Tuple(key2, value2);
            Assert.Equal(expected, tuple1.Equals(tuple2));
        }

        [Fact]
        public void ToString_CreateTuple_ConfirmToStringResult()
        {
            var tuple = new Tuple("key", "value");
            Assert.Equal("(key, value)", tuple.ToString());
        }
    }
}
