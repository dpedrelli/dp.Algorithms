using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class HashTableTester
    {
        //[Fact]
        //public void ComputeIndex_PassKeys_ConfirmBounds0to16()
        //{
        //    var table = new HashTable();
        //    for (int i = 0; i < 100; i++) 
        //    { 
        //        Assert.InRange(table.ComputeIndex("Key" + i.ToString()), 0, 16);
        //    }
        //}

        [Fact]
        public void PutTuple_GetTuple_ConfirmValue()
        {
            var table = new HashTable();
            table.Put("key", "value");
            Assert.Equal("value", table.Get("key"));
        }

        [Fact]
        public void ContainsKey_ValidKey_ReturnsTrue()
        {
            var table = new HashTable();
            table.Put("key", "value");
            Assert.True(table.ContainsKey("key"));
        }

        [Fact]
        public void ContainsKey_InvalidKey_ReturnsFalse()
        {
            var table = new HashTable();
            table.Put("key", "value");
            Assert.False(table.ContainsKey("key2"));
        }

        [Fact]
        public void ContainsValue_ValidValue_ReturnsTrue()
        {
            var table = new HashTable();
            table.Put("key", "value");
            Assert.True(table.ContainsValue("value"));
        }

        [Fact]
        public void ContainsValue_InvalidValue_ReturnsFalse()
        {
            var table = new HashTable();
            table.Put("key", "value");
            Assert.False(table.ContainsValue("value2"));
        }

        [Fact]
        public void CopyTable_GetTuple_VerifyValue()
        {
            var table = new HashTable();
            table.Put("key", "value");
            var newTable = table.Copy();
            Assert.Equal("value", newTable.Get("key"));
        }

        [Fact]
        public void RemoveTuple_ContainsKey_ReturnsFalse()
        {
            var table = new HashTable();
            table.Put("key", "value");
            Assert.True(table.ContainsKey("key"));
            Assert.Equal("value", table.Remove("key"));
            Assert.False(table.ContainsKey("key"));
        }

        [Fact]
        public void ToString_MatchesExpected()
        {
            var table = new HashTable();
            table.Put("key1", "value1");
            table.Put("key2", "value2");
            Assert.Equal("(key2, value2), (key1, value1), ", table.ToString());
        }

        [Fact]
        public void DoubleCapacity_Add16Items_ConfirmCapacityIs32()
        {
            var table = new HashTable();
            for (int i = 0; i < 16; i++)
            {
                table.Put("Key" + i.ToString(), "value");
            }
            Assert.Equal(32, table.Capacity);
        }
    }
}
