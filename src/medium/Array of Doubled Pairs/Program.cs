using System;
using System.Linq;
using System.Collections.Generic;

namespace Array_of_Doubled_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // false
            Console.WriteLine(program.CanReorderDoubled(new int[] { 3, 1, 3, 6 }));
            // false
            Console.WriteLine(program.CanReorderDoubled(new int[] { 2, 1, 2, 6 }));
            // true
            Console.WriteLine(program.CanReorderDoubled(new int[] { 4, -2, 2, -4 }));
            // false
            Console.WriteLine(program.CanReorderDoubled(new int[] { 1, 2, 4, 16, 8, 4 }));
            // true
            Console.WriteLine(program.CanReorderDoubled(new int[] { 2, 1, 2, 1, 1, 1, 2, 2 }));
            // true
            Console.WriteLine(program.CanReorderDoubled(new int[] { 0, 0 }));
            // true
            Console.WriteLine(program.CanReorderDoubled(new int[] { 1, 2, 1, -8, 8, -4, 4, -4, 2, -2 }));
            // true
            Console.WriteLine(program.CanReorderDoubled(new int[] { -6, 2, -6, 4, -3, 8, 3, 2, -2, 6, 1, -3, -4, -4, -8, 4 }));
            Console.WriteLine("Hello World!");
        }
        public bool CanReorderDoubled(int[] A)
        {
            if (A == null || A.Length == 0)
                return true;
            SortedDictionary<int, int> memo = new SortedDictionary<int, int>();
            foreach (var item in A)
            {
                memo.TryAdd(item, 0);
                memo[item]++;
            }
            while (memo.Count > 0)
            {
                int a = memo.First().Key;
                int aCnt = memo[a];
                memo.Remove(a);

                int key = 0;
                if (a < 0)
                    key = a / 2;
                else if (a > 0)
                    key = a * 2;
                else if (a == 0)
                    continue;

                if (memo.ContainsKey(key))
                {
                    if (memo[key] < aCnt)
                        return false;
                    else
                        memo[key] -= aCnt;
                    if (memo[key] == 0)
                        memo.Remove(key);
                }
                else
                    return false;
            }
            return true;
        }
    }
}
