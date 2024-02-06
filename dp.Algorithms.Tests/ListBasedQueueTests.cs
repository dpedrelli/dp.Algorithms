using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class ListBasedQueueTests
    {
        [Fact]
        public void ListQueue_Instantiate_NotNull()
        {
            var list = new ListBasedQueue<int>();
            Assert.NotNull(list);
        }

        [Fact]
        public void ListQueue_NoElements_IsEmptyTrue()
        {
            var list = new ListBasedQueue<int>();
            Assert.True(list.IsEmpty);
        }

        [Fact]
        public void ListQueue_EnqueueItem_SizeIs1()
        {
            var list = new ListBasedQueue<int>();
            list.Enqueue(1);
            Assert.Equal(1, list.Size);
        }

        [Fact]
        public void ListQueue_EnqueueItemDequeue_Value1IsEmpty()
        {
            var list = new ListBasedQueue<int>();
            list.Enqueue(1);
            var value = list.Dequeue();
            Assert.Equal(1, value);
            Assert.True(list.IsEmpty);
        }

        [Fact]
        public void ListQueue_EnqueueItemPeek_Value1()
        {
            var list = new ListBasedQueue<int>();
            list.Enqueue(1);
            var value = list.Peek();
            Assert.Equal(1, value);
            Assert.False(list.IsEmpty);
        }

        [Fact]
        public void ListQueue_ToString_ConfirmResult()
        {
            var list = new LinkedList<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            Assert.Equal("123", list.ToString());
        }
    }
}
