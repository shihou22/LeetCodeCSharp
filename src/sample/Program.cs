using System;

namespace sample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(getNum(new int[] { 3, 9, 24, 46, 88, 122, 158, 200, 367, 555, 912, 1543, 2323 }));
            // Console.WriteLine("1: " + fact(4));
            // Console.WriteLine("2: " + fact2(4, 1));

            char[] wk1 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] wk2 = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < wk1.Length; i++)
            {
                if (i < wk1.Length)
                    Console.WriteLine(wk1[i] + "-" + (char)(wk1[i] ^ 32));
                if (i < wk2.Length)
                    Console.WriteLine(wk2[i] + "-" + (char)(wk2[i] ^ 32));
            }
        }

        private string kujibiki(int[] nums, int m)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        for (int l = 0; l < n; l++)
                            if (nums[i] + nums[j] + nums[k] + nums[l] == m)
                                return "Yes";

            return "No";
        }
        private string kujibiki2(int[] nums, int m)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                    {
                        int wk = m - (nums[i] + nums[j] + nums[k]);
                        if (Array.BinarySearch(nums, wk) >= 0)
                            return "Yes";
                    }
            return "No";
        }
        private string kujibiki3(int[] nums, int m)
        {
            int n = nums.Length;
            int[] memo = new int[n * n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    memo[i * n + j] = nums[i] + nums[j];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    int wk = m - (nums[i] + nums[j]);
                    if (Array.BinarySearch(memo, wk) >= 0)
                        return "Yes";
                }
            return "No";
        }
        static int getNum(int[] nums)
        {
            int max = 10000;
            int min = int.MaxValue;
            int loop = 0;
            for (int i = 1; i <= max; i++)
            {
                for (int j = 1; j <= max; j++)
                {
                    int sum = 0;
                    int a1 = i;
                    int a2 = j;
                    sum += Math.Abs(nums[0] - a1);
                    sum += Math.Abs(nums[1] - a2);
                    if (sum > min)
                        continue;
                    for (int k = 2; k < nums.Length; k++)
                    {
                        sum += Math.Abs(nums[k] - (a1 + a2));
                        int wk = a1;
                        a1 = a2;
                        a2 += wk;
                        if (sum > min)
                            break;
                        loop++;
                    }
                    if (sum < min)
                        min = sum;
                    // Console.WriteLine("i:j = " + sum);
                }
            }
            Console.WriteLine(loop);
            return min;
        }

        static int fact(int i)
        {
            if (i == 0)
                return 1;
            return fact(i - 1) * i;
        }
        static int fact2(int i, int res)
        {
            if (i == 0)
                return res;
            return fact2(i - 1, res * i);
        }
        static void HogeMain(string[] args)
        {
            string[] s = Console.ReadLine().Split(' ');
            long A = long.Parse(s[0]);
            long B = long.Parse(s[1]);
            long X = long.Parse(s[2]);

            if (A + B > X)
            {
                Console.WriteLine(0);
                return;
            }
            int left = 1;
            int right = 1000000001;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                long cost = A * mid + B * numDigits(mid);
                if (cost > X)
                    right = mid;
                else
                    left = mid;

            }
            Console.WriteLine(left);
        }

        private static int numDigits(int a)
        {
            int d = 0;
            while (a > 0)
            {
                d++;
                a /= 10;
            }
            return d;
        }

    }
}
