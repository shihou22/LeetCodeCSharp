using System;

namespace Largest_Values_From_Labels
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var wk1 = solution.LargestValsFromLabels(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 1, 2, 2, 3 }, 3, 1);
            Console.WriteLine(wk1);//9
            var wk2 = solution.LargestValsFromLabels(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 3, 3, 3, 2 }, 3, 2);
            Console.WriteLine(wk2);//12
            var wk3 = solution.LargestValsFromLabels(new int[] { 9, 8, 8, 7, 6 }, new int[] { 0, 0, 0, 1, 1 }, 3, 1);
            Console.WriteLine(wk3);//16
            var wk4 = solution.LargestValsFromLabels(new int[] { 9, 8, 8, 7, 6 }, new int[] { 0, 0, 0, 1, 1 }, 3, 2);
            Console.WriteLine(wk4);//24
            Console.WriteLine("Hello World!");
        }
        public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit)
        {

        }
    }
}
