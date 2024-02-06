using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class LinkedListTester
    {
        [Fact]
        public void LinkedList_Instantiate_NotNull()
        {
            var list = new LinkedList<int>();
            Assert.NotNull(list);
        }

        [Fact]
        public void LinkedList_RemoveEmpty_ReceiveError()
        {
            var list = new LinkedList<int>();
            Assert.Throws<Exception>(() => list.RemoveFirst());
        }

        [Fact]
        public void LinkedList_PeekEmpty_ReceiveError()
        {
            var list = new LinkedList<int>();
            Assert.Throws<Exception>(() => list.Peek());
        }

        [Fact]
        public void LinkedList_Prepend_ConfirmNode()
        {
            var list = new LinkedList<int>();
            list.Prepend(10);
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list?._head?.Data);
        }

        [Fact]
        public void LinkedList_PrependTwice_ConfirmNodes()
        {
            var list = new LinkedList<int>();
            list.Prepend(10);
            list.Prepend(11);
            Assert.Equal(2, list.Size);
            Assert.Equal(11, list?._head?.Data);
            Assert.Equal(10, list?._head?.Next?.Data);
        }

        [Fact]
        public void LinkedList_PrependAndPeek_ConfirmNode()
        {
            var list = new LinkedList<int>();
            list.Prepend(10);
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list.Peek());
        }

        [Fact]
        public void LinkedList_PrependAndRemove_ConfirmSize()
        {
            var list = new LinkedList<int>();
            list.Prepend(10);
            Assert.Equal(1, list.Size);
            list.RemoveFirst();
            Assert.Equal(0, list.Size);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void LinkedList_InsertAtInvalid_ReceiveError(int index)
        {
            var list = new LinkedList<int>();
            Assert.Throws<Exception>(() => list.InsertAt(5, index));
        }

        [Fact]
        public void LinkedList_InsertAt0_ConfirmNode()
        {
            var list = new LinkedList<int>();
            list.InsertAt(10, 0);
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list?._head?.Data);
        }

        [Fact]
        public void LinkedList_InsertAt3_ConfirmNode()
        {
            var list = new LinkedList<int>();
            list.InsertAt(10, 0);
            list.InsertAt(11, 1);
            list.InsertAt(12, 2);
            list.InsertAt(13, 3);
            list.InsertAt(14, 4);
            list.InsertAt(15, 5);
            Assert.Equal(6, list.Size);
            Assert.Equal(10, list?._head?.Data);
            Assert.Equal(11, list?._head?.Next?.Data);
            Assert.Equal(12, list?._head?.Next?.Next?.Data);
            Assert.Equal(13, list?._head?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?._head?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(15, list?._head?.Next?.Next?.Next?.Next?.Next?.Data);
            list.InsertAt(16, 3);
            Assert.Equal(16, list?._head?.Next?.Next?.Next?.Data);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void LinkedList_RemoveAtInvalid_ReceiveError(int index)
        {
            var list = new LinkedList<int>();
            list.InsertAt(10, 0);
            list.InsertAt(11, 1);
            list.InsertAt(12, 2);
            list.InsertAt(13, 3);
            list.InsertAt(14, 4);
            list.InsertAt(15, 5);
            Assert.Throws<Exception>(() => list.RemoveAt(index));
        }

        [Fact]
        public void LinkedList_RemoveAt3_ConfirmRemoved()
        {
            var list = new LinkedList<int>();
            list.InsertAt(10, 0);
            list.InsertAt(11, 1);
            list.InsertAt(12, 2);
            list.InsertAt(13, 3);
            list.InsertAt(14, 4);
            list.InsertAt(15, 5);
            Assert.Equal(6, list.Size);
            Assert.Equal(10, list?._head?.Data);
            Assert.Equal(11, list?._head?.Next?.Data);
            Assert.Equal(12, list?._head?.Next?.Next?.Data);
            Assert.Equal(13, list?._head?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?._head?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(15, list?._head?.Next?.Next?.Next?.Next?.Next?.Data);
            var data = list.RemoveAt(3);
            Assert.Equal(5, list.Size);
            Assert.Equal(13, data);
            Assert.Equal(14, list?._head?.Next?.Next?.Next?.Data);
        }

        [Fact]
        public void LinkedList_RemoveData_ConfirmRemoved()
        {
            var list = new LinkedList<int>();
            list.InsertAt(10, 0);
            list.InsertAt(11, 1);
            list.InsertAt(12, 2);
            list.InsertAt(13, 3);
            list.InsertAt(14, 4);
            list.InsertAt(15, 5);
            list.InsertAt(13, 6);
            list.InsertAt(13, 7);
            Assert.Equal(8, list.Size);
            Assert.Equal(10, list?._head?.Data);
            Assert.Equal(11, list?._head?.Next?.Data);
            Assert.Equal(12, list?._head?.Next?.Next?.Data);
            Assert.Equal(13, list?._head?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?._head?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(15, list?._head?.Next?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(13, list?._head?.Next?.Next?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(13, list?._head?.Next?.Next?.Next?.Next?.Next?.Next?.Next?.Data);
            list.RemoveData(13);
            Assert.Equal(5, list.Size);
            Assert.Equal(14, list?._head?.Next?.Next?.Next?.Data);
        }

        [Fact]
        public void LinkedList_PeekEndEmpty_ReceiveError()
        {
            var list = new LinkedList<int>();
            Assert.Throws<Exception>(() => list.PeekEnd());
        }

        [Fact]
        public void LinkedList_PeekEnd_ConfirmData()
        {
            var list = new LinkedList<int>();
            list.InsertAt(10, 0);
            list.InsertAt(11, 1);
            list.InsertAt(12, 2);
            list.InsertAt(13, 3);
            list.InsertAt(14, 4);
            list.InsertAt(15, 5);
            list.InsertAt(13, 6);
            list.InsertAt(13, 7);
            Assert.Equal(13, list.PeekEnd());
        }

        [Fact]
        public void LinkedList_Append_ConfirmNode()
        {
            var list = new LinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            list.Append(15);
            Assert.Equal(6, list.Size);
            Assert.Equal(15, list.PeekEnd());
        }
    }
}
