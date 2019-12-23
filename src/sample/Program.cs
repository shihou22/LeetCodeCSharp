using System;

namespace sample
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("1: " + fact(4));
            Console.WriteLine("2: " + fact2(4, 1));
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
