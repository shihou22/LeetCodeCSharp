using System;
using System.Threading.Tasks;

namespace Print_in_Order
{
    public class Foo
    {
        private System.Threading.Tasks.TaskCompletionSource<object> firstCompletionSource = new System.Threading.Tasks.TaskCompletionSource<object>();
        private System.Threading.Tasks.TaskCompletionSource<object> secondCompletionSource = new System.Threading.Tasks.TaskCompletionSource<object>();

        public Foo()
        {

        }

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            firstCompletionSource.SetResult(new object());
        }

        public void Second(Action printSecond)
        {
            var ignored = firstCompletionSource.Task.Result;
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            secondCompletionSource.SetResult(new object());
        }

        public void Third(Action printThird)
        {
            var ignored = secondCompletionSource.Task.Result;
            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
}
