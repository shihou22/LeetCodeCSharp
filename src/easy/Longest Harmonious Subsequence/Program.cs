using System;
using System.Collections.Generic;

namespace Longest_Harmonious_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.FindLHS(new int[] { 1, 4, 1, 3, 1, -14, 1, -13 }));
            Console.WriteLine("Hello World!");
        }
        public int FindLHS(int[] nums)
        {
            SortedDictionary<int, int> res = new SortedDictionary<int, int>();
            foreach (var item in nums)
            {
                if (res.ContainsKey(item))
                    res[item]++;
                else
                    res.Add(item, 1);
            }
            int diff = 0;
            int numA = 0;
            int numB = 0;
            foreach (var item in res.Keys)
            {
                int currNum = item;
                int prevNum = item - 1;
                int currVal = res[currNum];
                int preVal = res.ContainsKey(prevNum) ? res[prevNum] : 0;
                int wk = currVal + preVal;
                if (currVal != 0 && preVal != 0 && wk > diff)
                {
                    diff = wk;
                    numA = currVal;
                    numB = preVal;
                }
            }
            if (numA != 0 && numB != 0)
                return numA + numB;
            else
                return 0;
        }
    }
}
