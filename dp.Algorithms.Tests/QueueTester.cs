namespace dp.Algorithms.Tests
{
    public class QueueTester
    {
        [Fact]
        public void Queue_Instantiate_NotNullConfirmCapacity()
        {
            var queue = new Queue<int>(5);
            Assert.NotNull(queue);
            Assert.Equal(5, queue.Capacity);
            Assert.Equal(0, queue.NumberInQueue);
            Assert.True(queue.IsEmpty);
        }

        [Fact]
        public void Queue_InstantiateInvalidCapacity_ReceiveError()
        {
            Assert.Throws<Exception>(() => new Queue<int>(0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Queue_EnqueueItem_ConfirmNumber(int numberToEnqueue)
        {
            var queue = new Queue<int>(5);
            for (int i = 0; i < numberToEnqueue; i++)
            {
                queue.Enqueue(1);
            }
            Assert.Equal(numberToEnqueue, queue.NumberInQueue);
        }

        [Fact]
        public void Queue_EnqueueFullQueue_ReceiveError()
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);
            queue.Enqueue(14);
            Assert.True(queue.IsFull);
            Assert.Throws<Exception>(() => queue.Enqueue(15));
        }

        [Fact]
        public void Queue_DequeueEmptyQueue_ReceiveError()
        {
            var queue = new Queue<int>(5);
            Assert.Throws<Exception>(() => queue.Dequeue());
        }

        [Fact]
        public void Queue_EnqueueItem_ConfirmDequeue()
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(10);
            Assert.Equal(10, queue.Dequeue());
            Assert.True(queue.IsEmpty);
        }

        [Fact]
        public void Queue_EnqueueItem_ConfirmPeek()
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(10);
            Assert.Equal(10, queue.Dequeue());
        }

        [Fact]
        public void Queue_ReduceCapacityLessThanItems_ReceiveError()
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            Assert.Throws<Exception>(() => queue.ChangeCapacity(2));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        public void Queue_ChangeCapacity_ConfirmNewCapacity(int newCapacity)
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.ChangeCapacity(newCapacity);
            Assert.Equal(newCapacity, queue.Capacity);
        }

        [Fact]
        public void Queue_EnqueueAndDequeueWrapping_ConfirmNumberInQueue()
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);
            queue.Enqueue(14);
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(15);
            Assert.Equal(4, queue.NumberInQueue);
        }

        [Fact]
        public void Queue_EnqueueAndDequeueItems_ConfirmToStringResult()
        {
            var queue = new Queue<char>(15);
            queue.Enqueue('1');
            queue.Enqueue('2');
            queue.Enqueue('3');
            queue.Enqueue('4');
            queue.Enqueue('5');
            queue.Enqueue('d');
            queue.Enqueue('e');
            queue.Enqueue('v');
            queue.Enqueue('i');
            queue.Enqueue('l');
            queue.Enqueue('d');
            queue.Enqueue('o');
            queue.Enqueue('g');
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.Equal("devildog", queue.ToString());
        }

        [Fact]
        public void Queue_EnqueueAndDequeueWrappingItems_ConfirmToStringResult()
        {
            var queue = new Queue<char>(10);
            queue.Enqueue('1');
            queue.Enqueue('2');
            queue.Enqueue('3');
            queue.Enqueue('4');
            queue.Enqueue('5');
            queue.Enqueue('d');
            queue.Enqueue('e');
            queue.Enqueue('v');
            queue.Enqueue('i');
            queue.Enqueue('l');
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue('d');
            queue.Enqueue('o');
            queue.Enqueue('g');
            Assert.Equal("devildog", queue.ToString());
        }

        [Fact]
        public void Queue_DoubleCapacity_ConfirmNewCapacity()
        {
            var queue = new Queue<int>(5);
            queue.DoubleCapacity();
            Assert.Equal(10, queue.Capacity);
        }

        [Fact]
        public void Queue_HalveCapacity_ConfirmNewCapacity()
        {
            var queue = new Queue<int>(10);
            queue.HalveCapacity();
            Assert.Equal(5, queue.Capacity);
        }
    }
}
