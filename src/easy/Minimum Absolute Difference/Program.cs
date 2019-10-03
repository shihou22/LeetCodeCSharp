using System;
using System.Collections.Generic;

namespace Minimum_Absolute_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);
            int min = int.MaxValue;
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 1; i < arr.Length; i++)
                min = Math.Min(arr[i] - arr[i - 1], min);

            for (int i = 1; i < arr.Length; i++)
            {
                if (min == arr[i] - arr[i - 1])
                {
                    IList<int> wk = new List<int>() { arr[i - 1], arr[i] };
                    res.Add(wk);
                }
            }
            return res;
        }
    }
}
