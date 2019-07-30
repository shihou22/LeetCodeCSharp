using System;

namespace Teemo_Attacking
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.FindPoisonedDuration(new int[] { 1, 4 }, 2));//4
            Console.WriteLine(solution.FindPoisonedDuration(new int[] { 1, 2 }, 2));//3
            Console.WriteLine("Hello World!");
        }
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries == null || timeSeries.Length == 0)
                return 0;
            long res = duration;
            for (int i = 1; i < timeSeries.Length; i++)
            {
                res += duration;
                int wk = timeSeries[i] - timeSeries[i - 1];
                if (wk < duration)
                    res -= (duration - wk);
            }
            return (int)res;
        }
    }
}
