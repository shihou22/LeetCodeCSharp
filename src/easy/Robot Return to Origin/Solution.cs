using System;

namespace Robot_Return_to_Origin
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool JudgeCircle(string moves)
        {
            int x = 0;
            int y = 0;
            foreach (var item in moves)
            {
                switch (item)
                {
                    case 'U':
                        y++;
                        break;
                    case 'D':
                        y--;
                        break;
                    case 'L':
                        x--;
                        break;
                    case 'R':
                        x++;
                        break;
                }
            }
            return x == 0 && y == 0;
        }
    }
}
