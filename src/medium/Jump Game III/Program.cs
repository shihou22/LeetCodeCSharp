using System;
using System.Collections.Generic;

namespace Jump_Game_III
{
    public class Pair<K, V>
    {
        public K key;
        public V val;
        public Pair(K key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.CanReach(new int[] { 4, 2, 3, 0, 3, 1, 2 }, 5));
            Console.WriteLine(program.CanReach(new int[] { 4, 2, 3, 0, 3, 1, 2 }, 0));
            Console.WriteLine(program.CanReach(new int[] { 3, 0, 2, 1, 2 }, 2));
            Console.WriteLine("Hello World!");
        }
        public bool CanReach(int[] arr, int start)
        {
            if (arr[start] == 0)
                return true;
            int max = arr.Length;
            ISet<int> visited = new HashSet<int>();
            Queue<Pair<int, int>> queue = new Queue<Pair<int, int>>();
            Pair<int, int> startI = new Pair<int, int>(start, 1);
            queue.Enqueue(startI);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    Pair<int, int> pair = queue.Dequeue();
                    if (pair.val + 1 > max)
                        continue;
                    int index = pair.key;
                    int minusI = index - arr[index];
                    if (minusI >= 0)
                    {
                        if (arr[minusI] == 0)
                            return true;
                        queue.Enqueue(new Pair<int, int>(minusI, pair.val + 1));
                    }
                    int plusI = index + arr[index];
                    if (plusI < max)
                    {
                        if (arr[plusI] == 0)
                            return true;
                        queue.Enqueue(new Pair<int, int>(plusI, pair.val + 1));
                    }
                }
            }
            return false;
        }
    }
}
