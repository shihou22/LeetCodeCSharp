using System;
using System.Collections.Generic;

namespace Element_Appearing_More_Than_25__In_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program program = new Program();
            int[] arr = new int[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 };
            Console.WriteLine(program.FindSpecialInteger(arr));
            int[] arr2 = new int[] { 1, 2, 3, 3 };
            Console.WriteLine(program.FindSpecialInteger(arr2));
        }
        public int FindSpecialInteger(int[] arr)
        {
            int rate = arr.Length / 4 + (arr.Length % 4 > 0 ? 1 : 0);
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                counts.TryAdd(item, 0);
                counts[item]++;
            }
            int cnt = 0;
            int val = 0;
            foreach (var item in counts)
            {
                if (item.Value > cnt)
                {
                    cnt = item.Value;
                    val = item.Key;
                }
            }
            return val;
        }
    }
}
