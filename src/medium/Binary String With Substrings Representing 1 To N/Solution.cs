using System;

namespace Binary_String_With_Substrings_Representing_1_To_N
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            // Console.WriteLine(solution.QueryString("0110", 3));//true
            // Console.WriteLine(solution.QueryString("0110", 4));//false
            Console.WriteLine(solution.QueryString("10010111100001110010", 10));//false
            Console.WriteLine("Hello World!");
        }
        public bool QueryString(string S, int N)
        {
            if (S.Length < 0 || S.Length > 1000 || N <= 0 || N > Math.Pow(10, 9))
                return false;

            for (int i = 1; i <= N; i++)
            {
                // Console.WriteLine(GetBinaryRepresentive(i));
                if (!S.Contains(GetBinaryRepresentive(i)))
                {
                    return false;
                }
            }
            return true;
        }
        private string GetBinaryRepresentive(int i)
        {
            string res = "";
            while (i > 0)
            {
                res = (i & 1).ToString() + res;
                i >>= 1;
            }
            return res;
        }
    }
}
