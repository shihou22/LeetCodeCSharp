using System;

namespace Play_with_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        /*
        chips -> chipのおかれている位置
        */
        public int MinCostToMoveChips(int[] chips)
        {
            int odd = 0;
            foreach (var chip in chips)
            {
                if (chip % 2 == 1)
                {
                    odd++;
                }
            }
            int even = chips.Length - odd;
            return Math.Min(odd, even);
        }
    }
}
