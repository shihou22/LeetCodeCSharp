using System;

namespace Maximize_Distance_to_Closest_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //2
            Console.WriteLine(program.MaxDistToClosest(new int[] { 1, 0, 0, 0, 1, 0, 1 }));
            //3
            Console.WriteLine(program.MaxDistToClosest(new int[] { 1, 0, 0, 0 }));
            Console.WriteLine("Hello World!");
        }

        public int MaxDistToClosest(int[] seats)
        {
            int lC = 0;
            int rC = 0;
            int count = 0;
            int res = 0;
            int n = seats.Length;
            bool l = true;
            bool r = true;
            for (int i = 0; i < n; i++)
            {
                if (l && seats[i] == 0)
                    lC++;
                else
                    l = false;

                if (r && seats[n - 1 - i] == 0)
                    rC++;
                else
                    r = false;

                if (seats[i] == 0)
                    count++;
                else
                    count = 0;
                res = Math.Max(Math.Max(res, (count + 1) / 2), Math.Max(lC, rC));
            }
            return res;
        }
    }
}
