using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class StackTester
    {
        [Fact]
        public void Stack_Instantiate_ConfirmSize()
        {
            var stack = new Stack<int>(5);
            Assert.Equal(5, stack.Capacity);
        }

        [Fact]
        public void Stack_PushFull_ReceiveError()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Assert.Throws<Exception>(() => stack.Push(6));
        }

        [Fact]
        public void Stack_PopEmpty_ReceiveError()
        {
            var stack = new Stack<int>(5);
            Assert.Throws<Exception>(() => stack.Pop());
        }

        [Fact]
        public void Stack_PushAndPop_ConfirmResult()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Size);
        }

        [Fact]
        public void Stack_PushAndPeek_ConfirmResult()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Equal(3, stack.Peek());
            Assert.Equal(3, stack.Size);
        }

        [Fact]
        public void Stack_ChangeInvalidCapacity_ReceiveError()
        {
            var stack = new Stack<int>(5);
            Assert.Equal(5, stack.Capacity);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Throws<Exception>(() => stack.ChangeCapacity(3));
        }

        [Fact] 
        public void Stack_ChangeCapacity_ConfirmNewCapacity()
        {
            var stack = new Stack<int>(5);
            Assert.Equal(5, stack.Capacity);
            stack.ChangeCapacity(10);
            Assert.Equal(10, stack.Capacity);
        }

        [Fact]
        public void Stack_ToString_ConfirmResult()
        {
            var stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Equal("123", stack.ToString());
        }
    }
}
