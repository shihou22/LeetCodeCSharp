using System;
using System.Linq;
using System.Collections.Generic;

namespace Most_Profit_Assigning_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // 100
            // Console.WriteLine(program.MaxProfitAssignment(new int[] { 2, 4, 6, 8, 10 }, new int[] { 10, 20, 30, 40, 50 }, new int[] { 4, 5, 6, 7 }));
            // 120
            // Console.WriteLine(program.MaxProfitAssignment(new int[] { 2, 4, 4, 8, 10 }, new int[] { 10, 20, 30, 40, 50 }, new int[] { 4, 5, 6, 7 }));
            // 0
            // Console.WriteLine(program.MaxProfitAssignment(new int[] { 85, 47, 57 }, new int[] { 24, 66, 99 }, new int[] { 40, 25, 2 }));
            // 324
            Console.WriteLine(program.MaxProfitAssignment(new int[] { 68, 35, 52, 47, 86 }, new int[] { 67, 17, 1, 81, 3 }, new int[] { 92, 10, 85, 84, 82 }));

            Console.WriteLine("Hello World!");
        }
        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            List<int[]> tmp = new List<int[]>();
            for (int i = 0; i < difficulty.Length; i++)
            {
                tmp.Add(new int[] { difficulty[i], profit[i] });
            }
            tmp.Sort((x, y) => x[0].CompareTo(y[0]) == 0 ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]));
            for (int i = 1; i < tmp.Count; i++)
            {
                tmp[i][1] = Math.Max(tmp[i][1], tmp[i - 1][1]);
            }
            int res = 0;
            foreach (var item in worker)
            {
                res += BinarySearch(tmp, item);
            }
            return res;
        }
        private int BinarySearch(List<int[]> tmp, int target)
        {
            int left = -1;
            int right = tmp.Count;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (target < tmp[mid][0])
                    right = mid;
                else
                    left = mid;
            }
            return left == -1 ? 0 : tmp[left][1];
        }
    }
}
