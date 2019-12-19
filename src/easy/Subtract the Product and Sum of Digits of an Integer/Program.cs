using System;
using System.Collections.Generic;

namespace Subtract_the_Product_and_Sum_of_Digits_of_an_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int SubtractProductAndSum(int n)
        {
            IList<int> wk = new List<int>();
            while (n != 0)
            {
                int r = n % 10;
                wk.Add(r);
                n /= 10;
            }
            int plus = 0;
            int mul = 1;
            foreach (var item in wk)
            {
                plus += item;
                mul *= item;
            }
            return mul - plus;
        }
    }
}
