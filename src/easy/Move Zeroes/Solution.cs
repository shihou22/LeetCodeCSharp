using System;

namespace Move_Zeroes
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] wk = null;
            wk= new int[] { 0, 1, 0, 3, 12 };
            solution.MoveZeroes(wk);
            Console.WriteLine(wk);
            // wk = new int[] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0 };
            // solution.MoveZeroes(wk);
            Console.WriteLine("Hello World!");
        }

        public void MoveZeroes(int[] nums)
        {
            var left = 0;
            var right = 1;
            while (left < right && left < nums.Length && right < nums.Length)
            {
                while (left < nums.Length && nums[left] != 0)
                    left++;

                right = left + 1;
                while (right < nums.Length && nums[right] == 0)
                    right++;

                if (left < nums.Length && right < nums.Length)
                {
                    var tmp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = tmp;
                }
                /*
                もし同じ位置に来たら++
                この時点でleftとrightのindexの差が1しかない時があるため、
                単純にleft++するとwhileの終了条件に該当してしまう。
                 */
                if (left == right)
                    left++;
            }
        }
    }
}
