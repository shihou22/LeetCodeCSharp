using System;

namespace Decode_Ways
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.NumDecodings("12"));//2
            Console.WriteLine(program.NumDecodings("226"));//3
            Console.WriteLine(program.NumDecodings("27"));//1
            Console.WriteLine(program.NumDecodings("260"));//0
            Console.WriteLine(program.NumDecodings("10"));//1
            Console.WriteLine(program.NumDecodings("01"));//0
            Console.WriteLine(program.NumDecodings("10107"));//1
            Console.WriteLine(program.NumDecodings("1010"));//1
            Console.WriteLine(program.NumDecodings("10127"));//2
            Console.WriteLine(program.NumDecodings("101"));//1
            Console.WriteLine("Hello World!");
        }
        public int NumDecodings(string s)
        {
            // return NumDecodingsDFS(s, 0);
            return NumDecodingsDP(s);
        }
        private int NumDecodingsDP(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            if (s[0] != '0')
                dp[1] = 1;

            for (int i = 2; i <= s.Length; i++)
            {
                if (s[i - 1] != '0')
                    dp[i] += dp[i - 1];

                int d = (s[i - 2] - '0') * 10 + (s[i - 1] - '0');
                if (d >= 10 && d <= 26)
                    dp[i] += dp[i - 2];
            }
            return dp[s.Length];
        }

        private int NumDecodingsDFS(string s, int curr)
        {
            if (curr == s.Length)
                return 1;
            else if (curr > s.Length)
                return 0;

            int sum = 0;
            if (s[curr] - '0' > 0 && s[curr] - '0' <= 9)
            {
                sum += NumDecodingsDFS(s, curr + 1);
            }

            int d = chkD(s, curr);
            if (d >= 10 && d <= 26)
            {
                sum += NumDecodingsDFS(s, curr + 2);
            }

            return sum;
        }
        private int chkD(string s, int curr)
        {
            if (curr + 1 >= s.Length)
                return s[curr] - '0';
            int wk = (s[curr] - '0') * 10 + (s[curr + 1] - '0');
            return wk;
        }
    }
}
