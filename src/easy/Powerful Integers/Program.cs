using System;
using System.Collections.Generic;

namespace Powerful_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //2,3,4,5,7,9,10
            // Console.WriteLine(program.PowerfulIntegers(2, 3, 10));
            //[65,2,5,41,44,17,56]
            Console.WriteLine(program.PowerfulIntegers(4, 40, 100));
            Console.WriteLine("Hello World!");
        }
        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            HashSet<int> tmp = new HashSet<int>();
            int max = (int)Math.Sqrt(bound);
            for (int i = 0; i <= max; i++)
            {
                for (int j = 0; j <= max; j++)
                {
                    long wk = (long)Math.Pow(x, i) + (long)Math.Pow(y, j);
                    Console.WriteLine(wk);
                    if (wk > 0 && wk <= bound)
                        tmp.Add((int)wk);
                    else
                        break;
                }
            }
            List<int> res = new List<int>(tmp);
            res.Sort();
            return res;
        }
        public IList<int> PowerfulIntegersSlow(int x, int y, int bound)
        {
            HashSet<int> tmp = new HashSet<int>();
            int max = (int)Math.Sqrt(bound);
            for (int i = 0; i <= max; i++)
            {
                for (int j = 0; j <= max; j++)
                {
                    var wk = Math.Pow(x, i) + Math.Pow(y, j);
                    if (wk > 0 && wk <= bound)
                        tmp.Add((int)wk);
                }
            }
            List<int> res = new List<int>(tmp);
            res.Sort();
            return res;
        }
    }
}
