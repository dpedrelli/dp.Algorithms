using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class ListBasedStackTests
    {
        [Fact]
        public void ListStack_Instantiate_NotNull()
        {
            var ls = new ListBasedStack<int>();
            Assert.NotNull(ls);
        }

        [Fact]
        public void ListStack_IsEmpty_ReturnsTrue()
        {
            var ls = new ListBasedStack<int>();
            Assert.True(ls.IsEmpty);
        }

        [Fact]
        public void ListStack_Push1_Size1()
        {
            var ls = new ListBasedStack<int>();
            ls.Push(1);
            Assert.Equal(1, ls.Size);
        }

        [Fact]
        public void ListStack_PeekEmpty_ReceiveError()
        {
            var ls = new ListBasedStack<int>();
            Assert.Throws<Exception>(() => ls.Peek());
        }

        [Fact]
        public void ListStack_Push1Peek_Returns1()
        {
            var ls = new ListBasedStack<int>();
            ls.Push(1);
            Assert.Equal(1, ls.Peek());
        }

        [Fact]
        public void ListStack_Push2Peek_Returns2()
        {
            var ls = new ListBasedStack<int>();
            ls.Push(1);
            ls.Push(2);
            Assert.Equal(2, ls.Peek());
        }

        [Fact]
        public void ListStack_PopEmpty_ReceiveError()
        {
            var ls = new ListBasedStack<int>();
            Assert.Throws<Exception>(() => ls.Pop());
        }

        [Fact]
        public void ListStack_Push1Pop_Returns1AndEmpty()
        {
            var ls = new ListBasedStack<int>();
            ls.Push(1);
            Assert.Equal(1, ls.Pop());
            Assert.True(ls.IsEmpty);
        }

        [Fact]
        public void ListStack_Push2Pop_ReturnsValuesAndResize()
        {
            var ls = new ListBasedStack<int>();
            ls.Push(1);
            ls.Push(2);
            Assert.Equal(2, ls.Pop());
            Assert.Equal(1, ls.Size);
            Assert.Equal(1, ls.Pop());
            Assert.True(ls.IsEmpty);
        }

        [Fact]
        public void ToString_Add123Elements_Equals123()
        {
            var list = new LinkedList<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            Assert.Equal("123", list.ToString());
        }

    }
}
