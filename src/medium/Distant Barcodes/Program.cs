using System;
using System.Linq;
using System.Collections.Generic;

namespace Distant_Barcodes
{

    // 指定されたIComparer<T>と逆の順序に並べ替えるIComparer<T>の実装
    class ReverseComparer<T> : IComparer<T>
    {
        private IComparer<T> comparer;

        public ReverseComparer(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            // 指定する引数の順序を逆にすることで、元になったIComparer<T>とは逆の結果を返す
            return comparer.Compare(y, x);
        }
    }
    // キーの重複がOKな優先度付きキュー
    public class PriorityQueue<TKey, TValue>
    {
        SortedDictionary<TKey, Queue<TValue>> dict = new SortedDictionary<TKey, Queue<TValue>>();
        int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Enqueue(TKey key, TValue value)
        {
            dict.TryAdd(key, new Queue<TValue>());
            dict[key].Enqueue(value);
            count++;
        }

        public KeyValuePair<TKey, TValue> Dequeue()
        {
            var queue = dict.Reverse().First();
            if (queue.Value.Count <= 1)
            {
                dict.Remove(queue.Key);
            }
            count--;
            return new KeyValuePair<TKey, TValue>(queue.Key, queue.Value.Dequeue());
        }
        public KeyValuePair<TKey, TValue> Poll()
        {
            var queue = dict.Reverse().First();
            return new KeyValuePair<TKey, TValue>(queue.Key, queue.Value.Dequeue());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //2,1,2,1,2,1
            // var res1 = program.RearrangeBarcodes(new int[] { 1, 1, 1, 2, 2, 2 });
            //1,3,1,3,2,1,2,1
            // var res2 = program.RearrangeBarcodes(new int[] { 1, 1, 1, 1, 2, 2, 3, 3 });
            // 1
            // var res3 = program.RearrangeBarcodes(new int[] { 1 });
            // 2,3,2,1
            var res4 = program.RearrangeBarcodes(new int[] { 2, 2, 1, 3 });
            Console.WriteLine("Hello World!");
        }
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            foreach (var item in barcodes)
            {
                memo.TryAdd(item, 0);
                memo[item]++;
            }
            PriorityQueue<int, int> p = new PriorityQueue<int, int>();
            var bList = barcodes.OrderBy(x => x).ToList();
            foreach (var item in memo)
            {
                p.Enqueue(item.Value, item.Key);
            }
            int cnt = 0;
            while (p.Count > 1)
            {
                var elm1 = p.Dequeue();
                var elm2 = p.Dequeue();
                barcodes[cnt++] = elm1.Value;
                barcodes[cnt++] = elm2.Value;
                if (elm1.Key - 1 > 0)
                    p.Enqueue(elm1.Key - 1, elm1.Value);
                if (elm2.Key - 1 > 0)
                    p.Enqueue(elm2.Key - 1, elm2.Value);
            }
            if (p.Count > 0)
            {
                barcodes[cnt++] = p.Dequeue().Value;
            }
            return barcodes;
        }
    }
}
