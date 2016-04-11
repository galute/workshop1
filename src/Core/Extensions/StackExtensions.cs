using System.Collections.Generic;
using System.Linq;

namespace Workshop.Extensions
{
    public static class StackExtensions
    {
        public static Stack<T> With<T>(this Stack<T> stack, params T[] elements)
        {
            var updatedStack = new Stack<T>(stack.Reverse());
            foreach (var element in elements)
            {
                updatedStack.Push(element);
            }
            return updatedStack;
        }
    }
}