using System.Collections.Generic;

namespace dp.Algorithms.Tests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void DLinkedList_Instantiate_NotNull()
        {
            var list = new DoublyLinkedList<int>();
            Assert.NotNull(list);
        }

        [Fact]
        public void DLinkedList_RemoveEmpty_ReceiveError()
        {
            var list = new DoublyLinkedList<int>();
            Assert.Throws<Exception>(() => list.RemoveFirst());
        }

        [Fact]
        public void DLinkedList_PeekEmpty_ReceiveError()
        {
            var list = new DoublyLinkedList<int>();
            Assert.Throws<Exception>(() => list.Peek());
        }

        [Fact]
        public void DLinkedList_Prepend_ConfirmNode()
        {
            var list = new DoublyLinkedList<int>();
            list.Prepend(10);
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list?.Head?.Data);
        }

        [Fact]
        public void DLinkedList_PrependTwice_ConfirmNodes()
        {
            var list = new DoublyLinkedList<int>();
            list.Prepend(10);
            list.Prepend(11);
            Assert.Equal(2, list.Size);
            Assert.Equal(11, list?.Head?.Data);
            Assert.Null(list?.Head?.Previous);
            Assert.Equal(10, list?.Head?.Next?.Data);
            Assert.NotNull(list?.Head?.Next?.Previous);
            Assert.Equal(11, list?.Head?.Next?.Previous?.Data);
            Assert.Equal(10, list?.Tail?.Data);
        }

        [Fact]
        public void DLinkedList_PrependAndPeek_ConfirmNode()
        {
            var list = new DoublyLinkedList<int>();
            list.Prepend(10);
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list.Peek());
        }

        [Fact]
        public void DLinkedList_Append_ConfirmHeadNextPreviousTail()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            list.Append(15);
            Assert.Equal(6, list.Size);
            Assert.Equal(10, list?.Head?.Data);
            Assert.Equal(11, list?.Head?.Next?.Data);
            Assert.Equal(14, list?.Tail?.Previous?.Data);
            Assert.Equal(15, list?.Tail?.Data);
        }

        [Fact]
        public void DLinkedList_Append1AndRemoveFirst_ConfirmEmpty()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            var value = list.RemoveFirst();
            Assert.True(list.IsEmpty);
            Assert.Null(list.Head);
            Assert.Null(list.Tail);
            Assert.Equal(10, value);
        }

        [Fact]
        public void DLinkedList_AppendMultipleAndRemoveFirst_ConfirmHead()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            var value = list.RemoveFirst();
            Assert.Equal(10, value);
            Assert.False(list.IsEmpty);
            Assert.Equal(11, list.Head?.Data);
            Assert.Equal(14, list.Tail?.Data);
        }

        [Fact]
        public void DLinkedList_AppendMultipleAndRemoveLast_ConfirmHead()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            var value = list.RemoveLast();
            Assert.Equal(14, value);
            Assert.False(list.IsEmpty);
            Assert.Equal(10, list.Head?.Data);
            Assert.Equal(13, list.Tail?.Data);
        }

        [Fact]
        public void DLinkedList_InsertAt2_ConfirmNode()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            list.InsertAt(16, 2);
            Assert.Equal(6, list.Size);
            Assert.Equal(10, list?.Head?.Data);
            Assert.Equal(11, list?.Head?.Next?.Data);

            Assert.Equal(11, list?.Head?.Next?.Next?.Previous?.Data);
            Assert.Equal(16, list?.Head?.Next?.Next?.Data);

            Assert.Equal(12, list?.Head?.Next?.Next?.Next?.Data);
            Assert.Equal(16, list?.Head?.Next?.Next?.Next?.Previous?.Data);

            Assert.Equal(13, list?.Head?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?.Head?.Next?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?.Tail?.Data);
        }

        [Fact]
        public void DLinkedList_RemoveAt2_ConfirmRemoved()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            var data = list.RemoveAt(2);
            Assert.Equal(4, list.Size);
            Assert.Equal(12, data);
        }

        [Fact]
        public void DLinkedList_PeekEnd_Returns14()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            Assert.Equal(14, list.PeekEnd());
        }

        [Fact]
        public void DLinkedList_GetNextEmpty_ReturnsDefault()
        {
            var list = new DoublyLinkedList<int>();
            Assert.Equal(0, list.GetNext());
        }

        [Fact]
        public void DLinkedList_GetNext3Times_Returns101112()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            Assert.Equal(10, list.GetNext());
            Assert.Equal(11, list.GetNext());
            Assert.Equal(12, list.GetNext());
        }

        [Fact]
        public void DLinkedList_Reset_CurrentIsNull()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            list.GetNext();
            list.GetNext();
            list.GetNext();
            list.Reset();
            Assert.Null(list.Current);
        }

        [Fact]
        public void DLinkedList_RemoveCurrentEmpty_ReceiveError()
        {
            var list = new DoublyLinkedList<int>();
            Assert.Throws<Exception>(() => list.RemoveCurrent());
        }

        [Fact]
        public void DLinkedList_RemoveCurrent_Current11()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            list.GetNext();
            list.GetNext();
            list.GetNext();
            list.RemoveCurrent();
            Assert.Equal(11, list?.Current?.Data);
            for (int i = 0; i < list?.Size; i++)
            {
                Assert.NotEqual(12, list.GetNext());
            }
        }

        [Fact]
        public void DLinkedList_DeleteAll11_ConfirmNo11()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(11);
            list.Append(13);
            list.Append(11);
            list.Append(14);
            list.Append(11);
            list.DeleteAll(11);
            for (int i = 0; i < list.Size; i++)
            {
                Assert.NotEqual(11, list.GetNext());
            }
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
