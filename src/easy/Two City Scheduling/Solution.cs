using System;

namespace Two_City_Scheduling
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[][] input = new int[][] {
            new []{259, 770},
            new []{448, 54},
            new[] { 926, 667},
            new[] { 184, 139},
            new []{840, 118},
            new []{577, 469}
        };
            Console.WriteLine(solution.TwoCitySchedCost(input));
            Console.WriteLine("Hello World!");
        }
        public int TwoCitySchedCost(int[][] costs)
        {
            int res = 0;
            foreach (var item in costs)
            {
                res += item[0] < item[1] ? item[0] : item[1];
            }
            return res;
        }
    }
}
