using System;
using System.Collections.Generic;
using System.Linq;

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
            int cost = 0;
            var ls = costs.OrderBy(x => { return x[0] - x[1]; });
            int cnt = costs.Length / 2;
            foreach (var item in ls)
            {
                if (cnt > 0)
                    cost += item[0];
                else
                    cost += item[1];

                cnt--;
            }
            return cost;
        }
        public int TwoCitySchedCostRecursive(int[][] costs)
        {
            int n = costs.Length;
            recursive(costs, n / 2, n / 2, 0, 0, 0);
            return totalCost;
        }

        private int totalCost = int.MaxValue;
        private void recursive(int[][] costs, int a, int b, int costA, int costB, int currentI)
        {
            if (a <= 0 && b <= 0 || currentI >= costs.Length)
            {
                if (a == 0 && b == 0)
                    totalCost = Math.Min(totalCost, costA + costB);

                return;
            }

            recursive(costs, a - 1, b, costA + costs[currentI][0], costB, currentI + 1);
            recursive(costs, a, b - 1, costA, costB + costs[currentI][1], currentI + 1);
        }
    }
}
