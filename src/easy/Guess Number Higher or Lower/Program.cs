using System;

namespace Guess_Number_Higher_or_Lower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        private int guess(int num)
        {
            return 1;
        }
        public int guessNumber(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (guess(mid) == 0)
                    return mid;
                else if (guess(mid) == -1)
                    right = mid;
                else if (guess(mid) == 1)
                    left = mid + 1;
            }
            return left;
        }
    }
}
