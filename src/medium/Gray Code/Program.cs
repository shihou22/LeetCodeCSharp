using System;
using System.Collections.Generic;

namespace Gray_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.GrayCode(2));
            Console.WriteLine(0 ^ (0 >> 1));
            Console.WriteLine(1 ^ (1 >> 1));
            Console.WriteLine(2 ^ (2 >> 1));
            Console.WriteLine(3 ^ (3 >> 1));
            Console.WriteLine("Hello World!");
        }
        public IList<int> GrayCode(int n)
        {
            IList<int> res = new List<int>();
            for (int i = 0; i < 1 << n; i++)
            {
                res.Add(i ^ (i >> 1));
            }
            return res;
        }
    }
}
