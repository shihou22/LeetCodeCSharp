using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Negative_Numbers_in_a_Sorted_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountNegatives(int[][] grid)
        {
            int cnt = grid.Select(x => x.Where(y => y < 0).Count()).Sum();
            return cnt;
        }
    }
}
