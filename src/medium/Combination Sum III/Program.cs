using System;
using System.Collections.Generic;

namespace Combination_Sum_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            Helper(k, n, 1, new List<int>(), 0);
            return res;
        }
        private IList<IList<int>> res = new List<IList<int>>();
        private void Helper(int k, int n, int curr, IList<int> wk, int total)
        {
            if (wk.Count == k || curr > 9)
            {
                if (wk.Count == k && total == n)
                    res.Add(new List<int>(wk));

                return;
            }
            wk.Add(curr);
            Helper(k, n, curr + 1, wk, total + curr);
            wk.RemoveAt(wk.Count - 1);
            Helper(k, n, curr + 1, wk, total);
        }
    }
}
