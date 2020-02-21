using System;
using System.Linq;
using System.Collections.Generic;

namespace Asteroid_Collision
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // var res1 = program.AsteroidCollision(new int[] { 5, 10, -5 });//[5,10]
            // var res2 = program.AsteroidCollision(new int[] { 8, -8 });//[]
            // var res3 = program.AsteroidCollision(new int[] { -2, -1, 1, 2 });//[-2,-1,1,2]
            var res4 = program.AsteroidCollision(new int[] { 1, -2, -2, -2 });//[-2,-2,-2]
            Console.WriteLine("Hello World!");
        }
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();
            foreach (var item in asteroids)
            {
                if (item > 0)
                    stack.Push(item);
                else
                    calc(stack, item);
            }
            return stack.Reverse().ToArray();
        }
        private void calc(Stack<int> stack, int asteroid)
        {
            while (stack.Count > 0)
            {
                int p = stack.Pop();
                if (p < 0)
                {
                    stack.Push(p);
                    break;
                }
                else if (Math.Abs(asteroid) < p)
                {
                    stack.Push(p);
                    asteroid = 0;
                    break;
                }
                else if (Math.Abs(asteroid) == p)
                {
                    asteroid = 0;
                    break;
                }

            }
            if (asteroid != 0)
                stack.Push(asteroid);
        }
    }
}
