using System;
using System.Collections.Generic;
using System.Linq;

namespace Kth_Largest_Element_in_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //5
            Console.WriteLine(program.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2)); ;
            //4
            Console.WriteLine(program.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4)); ;
            Console.WriteLine("Hello World!");
        }
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>((x, y) => x.CompareTo(y));
            foreach (var item in nums)
            {
                pq.Enqueue(item);
                if (pq.Count > k)
                    pq.Dequeue();
            }
            return pq.Peek();
        }
        public class PriorityQueue<T>
        {
            List<T> list = new List<T>();
            IComparer<T> comp = Comparer<T>.Default;
            class Comparer : IComparer<T>
            {
                Comparison<T> comparison;
                public Comparer(Comparison<T> comparison) { this.comparison = comparison; }
                public int Compare(T x, T y) { return comparison(x, y); }
            }
            public PriorityQueue() { }
            public PriorityQueue(Comparison<T> comp) { this.comp = new Comparer(comp); }
            public void Enqueue(T item) { int i = list.BinarySearch(item, comp); list.Insert(i < 0 ? ~i : i, item); }
            public T Dequeue() { T r = list[0]; list.RemoveAt(0); return r; }
            public T Peek() { return list[0]; }
            public int Count { get { return list.Count; } }
            public T this[int i] { get { return list[i]; } set { list[i] = value; } }
        }
        public int FindKthLargestSort(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }
    }

}
