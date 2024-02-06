﻿using System.Collections.Generic;

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
        public void LinkedList_Prepend_ConfirmNode()
        {
            var list = new DoublyLinkedList<int>();
            list.Prepend(10);
            Assert.Equal(1, list.Size);
            Assert.Equal(10, list?._head?.Data);
        }

        [Fact]
        public void DLinkedList_PrependTwice_ConfirmNodes()
        {
            var list = new DoublyLinkedList<int>();
            list.Prepend(10);
            list.Prepend(11);
            Assert.Equal(2, list.Size);
            Assert.Equal(11, list?._head?.Data);
            Assert.Null(list?._head?.Previous);
            Assert.Equal(10, list?._head?.Next?.Data);
            Assert.NotNull(list?._head?.Next?.Previous);
            Assert.Equal(11, list?._head?.Next?.Previous?.Data);
            Assert.Equal(10, list?._tail?.Data);
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
            Assert.Equal(10, list?._head?.Data);
            Assert.Equal(11, list?._head?.Next?.Data);
            Assert.Equal(14, list?._tail?.Previous?.Data);
            Assert.Equal(15, list?._tail?.Data);
        }

        [Fact]
        public void DLinkedList_Append1AndRemoveFirst_ConfirmEmpty()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            var value = list.RemoveFirst();
            Assert.True(list.IsEmpty);
            Assert.Null(list._head);
            Assert.Null(list._tail);
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
            Assert.Equal(11, list._head?.Data);
            Assert.Equal(14, list._tail?.Data);
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
            Assert.Equal(10, list._head?.Data);
            Assert.Equal(13, list._tail?.Data);
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
            Assert.Equal(10, list?._head?.Data);
            Assert.Equal(11, list?._head?.Next?.Data);

            Assert.Equal(11, list?._head?.Next?.Next?.Previous?.Data);
            Assert.Equal(16, list?._head?.Next?.Next?.Data);

            Assert.Equal(12, list?._head?.Next?.Next?.Next?.Data);
            Assert.Equal(16, list?._head?.Next?.Next?.Next?.Previous?.Data);

            Assert.Equal(13, list?._head?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?._head?.Next?.Next?.Next?.Next?.Next?.Data);
            Assert.Equal(14, list?._tail?.Data);
        }

        [Fact]
        public void LinkedList_RemoveAt2_ConfirmRemoved()
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
        public void LinkedList_PeekEnd_Returns14()
        {
            var list = new DoublyLinkedList<int>();
            list.Append(10);
            list.Append(11);
            list.Append(12);
            list.Append(13);
            list.Append(14);
            Assert.Equal(14, list.PeekEnd());
        }
    }
}
