using System;
using System.Collections.Generic;

namespace Rotated_Digits
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.RotatedDigits(10));//4
            Console.WriteLine(solution.GetRoatedNum(111));
            // Console.WriteLine(solution.RotatedDigits(10));//4
            Console.WriteLine("Hello World!");
        }
        public int RotatedDigits(int N)
        {
            int res = 0;
            HashSet<int> set = new HashSet<int>();
            for (int i = 1; i <= N; i++)
            {
                if (GetRoatedNum(i))
                    res++;
            }
            return res;
        }
        private bool GetRoatedNum(int i)
        {
            bool isExistRotateNum = false;
            while (i > 0)
            {
                int wk = i % 10;
                switch(wk){
                    case 2:
                    case 5:
                    case 6:
                    case 9:
                    isExistRotateNum = true;
                    break;
                    case 1:
                    case 8:
                    break;
                    case 3:
                    case 4:
                    case 7:
                    return false;
                }
                i /= 10;
            }
            return isExistRotateNum;
        }
    }
}
