using System;

namespace Water_and_Jug_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //true
            Console.WriteLine(program.CanMeasureWater(3, 5, 4));
            Console.WriteLine("Hello World!");
        }
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (x == 0 && y == 0)
                return z == 0;
            int g = Gcd(x, y);
            return z % g == 0 && z <= (x + y);
        }
        private int Gcd(int a, int b)
        {
            // if (b == 0)
            //     return a;
            // else
            //     return Gcd(b, a % b);
            int wA = Math.Max(a, b);
            int wB = Math.Min(a, b);
            if (wB == 0)
                return 1;
            int amar = wA % wB;
            while (amar != 0)
            {
                wA = wB;
                wB = amar;
                amar = wA % wB;
            }
            return wB;
        }
    }
}
