using System;

namespace Mirror_Reflection
{
    class Solution
    {
        /*
        https://leetcode.com/problems/mirror-reflection/discuss/313520/most-detailed-explanation-rather-than-code-of-course-including-code
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MirrorReflection(int p, int q)
        {
            int k = 1;
            /*
            x/p = y/q
            K * p mod q=0 となるもの
            x の長さ
             */
            while (p * k % q != 0)
                k += 1;
            // k = GetGcd(p, q);

            if (k % 2 == 0)
                return 0;

            int r = p * k / q;
            if (r % 2 == 0)
                return 2;
            if (r % 2 == 1)
                return 1;

            return -1;
        }
        private int GetLCM(int p, int q)
        {
            return p * q / GetGcd(p, q);
        }
        private int GetGcd(int p, int q)
        {
            int a = Math.Max(p, q);
            int b = Math.Min(p, q);
            int mod = a % b;
            while (mod != 0)
            {
                a = b;
                b = mod;
                mod = a % b;
            }
            return b;
        }
    }
}
