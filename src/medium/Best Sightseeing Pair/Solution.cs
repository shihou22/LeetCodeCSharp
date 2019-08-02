using System;

namespace Best_Sightseeing_Pair
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.MaxScoreSightseeingPair(new int[] { 8, 1, 5, 2, 6 }));//11
            Console.WriteLine("Hello World!");
        }
        public int MaxScoreSightseeingPair(int[] A)
        {
            int max = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    max = Math.Max((A[i] + A[j]) + (i - j), max);
                }
            }
            return max;
        }
    }
}
