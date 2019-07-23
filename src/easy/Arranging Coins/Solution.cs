using System;

namespace Arranging_Coins
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.ArrangeCoins(1));//1
            Console.WriteLine(solution.ArrangeCoins(3));//2
            Console.WriteLine(solution.ArrangeCoins(4));//2
            Console.WriteLine(solution.ArrangeCoins(5));//2
            Console.WriteLine(solution.ArrangeCoins(8));//3
            Console.WriteLine(solution.ArrangeCoins(1000000000));
            Console.WriteLine("Hello World!");
        }
        public int ArrangeCoins(int n)
        {
            if (n == 0)
                return 0;
            long left = 1;
            long right = n;
            long mid = left + (right - left) / 2;
            while (left < mid && mid < right)
            {
                long midSum = (mid) * (mid + 1) / 2;
                long leftSum = (left) * (left + 1) / 2;
                long rightSum = (right) * (right + 1) / 2;
                if (leftSum <= n && n < midSum)
                    right = mid;
                else if (midSum < n && n <= rightSum)
                    left = mid;
                else
                    break;

                mid = left + (right - left) / 2;
            }
            return unchecked((int)mid);
        }
    }
}
