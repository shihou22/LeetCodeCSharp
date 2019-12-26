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
