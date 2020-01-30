using System;

namespace Elimination_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //6
            Console.WriteLine(program.LastRemaining(9));
            //2
            Console.WriteLine(program.LastRemaining(3));
            //1
            Console.WriteLine(program.LastRemaining(1));
            Console.WriteLine(program.LastRemaining(12));
            Console.WriteLine(program.LastRemaining(10));
            Console.WriteLine(program.LastRemaining(6));
            Console.WriteLine("Hello World!");
        }
        /*
        1 2 3 4 5 6 7 8 9
        2 4 6 8
        2 6
        6
        1 2 3 4 5 6 7 8 9 10 11 12
        2 4 6 8 10 12
        2 6 10
        6
        1 2 3 4 5 6 7 8 9 10
        2 4 6 8 10
        4 8
        8
        1 2 3 4 5 6
        2 4 6
        4 
        */
        private int Helper(int n, int curr, int diff, bool fromLeft)
        {
            if (n == 1)
            {
                return curr;
            }

            if (fromLeft)
            {
                curr += diff;
            }
            else
            {
                if (n % 2 == 1)
                {
                    curr += diff;
                }
            }

            return Helper(n / 2, curr, diff * 2, !fromLeft);
        }

        public int LastRemaining(int n)
        {
            return Helper(n, 1, 1, true);
        }
    }
}
