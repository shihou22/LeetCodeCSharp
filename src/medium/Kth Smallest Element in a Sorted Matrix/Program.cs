using System;
using System.Linq;
using System.Collections.Generic;

namespace Kth_Smallest_Element_in_a_Sorted_Matrix
{

    class PriorityQueue<T>
    {
        List<T> queue = new List<T>();
        IComparer<T> comparer = Comparer<T>.Default;
        class Comparer : IComparer<T>
        {
            Comparison<T> comparison;
            public Comparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }
            public int Compare(T x, T y)
            {
                return comparison(x, y);
            }
        }
        public PriorityQueue(Comparison<T> comparison)
        {
            this.comparer = new Comparer(comparison);
        }
        public void Enqueue(T item)
        {
            int i = queue.BinarySearch(item, comparer);
            queue.Insert(i < 0 ? ~i : i, item);
        }
        public T Dequeue()
        {
            T r = queue[0];
            queue.RemoveAt(0);
            return r;
        }
        public T Peek()
        {
            return queue[0];
        }
        public int Count
        {
            get { return queue.Count; }
        }
        public T this[int i]
        {
            get { return queue[i]; }
            set { queue[i] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[][] args1 = new int[3][];
            args1[0] = new int[] { 1, 5, 9 };
            args1[1] = new int[] { 10, 11, 13 };
            args1[2] = new int[] { 12, 13, 15 };
            Console.WriteLine(program.KthSmallest(args1, 8));
            Console.WriteLine("Hello World!");
        }
        public int KthSmallest(int[][] matrix, int k)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>((x, y) => -x.CompareTo(y));
            foreach (var item in matrix)
            {
                foreach (var inner in item)
                {
                    pq.Enqueue(inner);
                    if (pq.Count > k)
                        pq.Dequeue();
                }
            }
            return pq.Peek();
        }
    }
}
